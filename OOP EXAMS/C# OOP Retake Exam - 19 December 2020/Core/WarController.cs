using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{

        private readonly List<Character> party;
		private readonly List<Item> pool;

        public WarController()
		{
			this.party = new List<Character>();
			this.pool = new List<Item>();
		}

		public IReadOnlyCollection<Item> Pool => this.pool.AsReadOnly();
		public IReadOnlyCollection<Character> Party => this.party.AsReadOnly();



		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			Character character = null;

            if (characterType == "Warrior")
            {
				character = new Warrior(name);
            }
            if (characterType == "Priest")
            {
				character = new Priest(name);
            }

            if (character == null)
            {
				throw new ArgumentException(String.Format(ExceptionMessages.InvalidCharacterType, characterType)) ;
            }

			party.Add(character);

			return string.Format(SuccessMessages.JoinParty, name);

		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

			Item item = null;
			if (itemName == "HealthPotion")
			{
				item = new HealthPotion();
			}
			else if (itemName == "FirePotion")
			{
				item = new FirePotion();
			}
			else
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
			}

			pool.Add(item);

			return string.Format(SuccessMessages.AddItemToPool, itemName);


		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
            if (!party.Any(c => c.Name == characterName))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (!pool.Any())
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
			}

			Character character = party.FirstOrDefault(c => c.Name == characterName);

			Item item = pool[pool.Count - 1];
			

			character.Bag.AddItem(item);
			pool.Remove(item);
			

			return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);

		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character = party.FirstOrDefault(c => c.Name == characterName);
            if (character == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }


			  Item item =  character.Bag.GetItem(itemName);
			character.UseItem(item);

			return string.Format(SuccessMessages.UsedItem, characterName, itemName);

			
		}

		public string GetStats()
		{

            StringBuilder sb = new StringBuilder();

            foreach (var character in party.OrderByDescending(c => c.IsAlive).ThenByDescending(c =>c.Health))
            {

				sb.AppendLine(string.Format(SuccessMessages.CharacterStats, character.Name, character.Health,character.BaseHealth,character.Armor, character.BaseArmor, (character.IsAlive ? "Alive" : "Dead") ));

				//sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {character.IsAlive}");

            }
			return sb.ToString().TrimEnd();
			}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			Character attacker = party.FirstOrDefault(a => a.Name == attackerName);
			Character reciever = party.FirstOrDefault(a => a.Name == receiverName);

            if (attacker == null)
            {
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
			if (receiverName == null)
            {
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}

			if (!(attacker is IAttacker))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
			}


			//Warrior attackerWarrior = attacker as Warrior;

			//attackerWarrior.Attack(reciever);

			((IAttacker)attacker).Attack(reciever);

           


			string result = string.Format(SuccessMessages.AttackCharacter, attacker.Name, reciever.Name, attacker.AbilityPoints, reciever.Name, reciever.Health, reciever.BaseHealth, reciever.Armor, reciever.BaseArmor);
            if (!reciever.IsAlive)
            {
				result += Environment.NewLine + String.Format(SuccessMessages.AttackKillsCharacter, receiverName);

            }

			return result;
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			Character healer = party.FirstOrDefault(a => a.Name == healerName);
			Character reciever = party.FirstOrDefault(a => a.Name == healingReceiverName);

			if (healer == null)
			{
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healerName));
			}
			if (reciever == null)
			{
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
			}

            if (!(healer is IHealer))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

			((IHealer)healer).Heal(reciever);


			string result = string.Format(SuccessMessages.HealCharacter, healerName, healingReceiverName, healer.AbilityPoints, healingReceiverName, reciever.Health);

			return result;

		}
	}
}
