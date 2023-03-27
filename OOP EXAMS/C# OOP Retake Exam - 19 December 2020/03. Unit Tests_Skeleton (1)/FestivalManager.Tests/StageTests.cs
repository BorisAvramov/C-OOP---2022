// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    //using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

	[TestFixture]
	public class StageTests
	{
		[Test]
		public void Positive_ConstructorShouldInitialCollectionsSongsAndPerformers()
		{

			Stage stage = new Stage();



			Assert.NotNull(stage.Performers);

			Assert.That(stage.Performers, Is.Not.Null);
			Assert.AreEqual(0, stage.Performers.Count);

		}

		[Test]

		public void Negative_AddPerformer_WhenPerformerIsNull()
		{
			Stage stage = new Stage();

			Performer performer = null;

			Assert.Throws<ArgumentNullException>(
				() => stage.AddPerformer(performer)

				);

		}
		[Test]

		public void Negative_AddPerformer_WhenPerformerIsUnder18YearsOld()
		{
			Stage stage = new Stage();

			Performer performer = new Performer("Sue", "Avramova", 17);

			Assert.Throws<ArgumentException>(
				() => stage.AddPerformer(performer)

				);

		}

		[Test]

		public void Positive_AddPerformer()
		{
			Stage stage = new Stage();

			Performer performer = new Performer("Sue", "Avramova", 31);

			stage.AddPerformer(performer);

			Assert.AreEqual(1, stage.Performers.Count);
			Assert.That(stage.Performers.Any(p => p.FullName == "Sue Avramova" && p.Age == 31));

		}
		[Test]

		public void Negative_AddSong_WhenSongIsNull()
		{
			Stage stage = new Stage();

			Song song = null;

			Assert.Throws<ArgumentNullException>(
				() => stage.AddSong(song)

				);

		}
		[Test]

		public void Negative_AddSong_WhenSongDurationIsUnder1Min()
		{
			Stage stage = new Stage();

			Song song = new Song("Happy", new TimeSpan(0, 0, 59));

			Assert.Throws<ArgumentException>(
				() => stage.AddSong(song)

				);

		}
		[Test]

		public void Positive_AddSong_()
		{
			Stage stage = new Stage();

			Song song = new Song("Happy", new TimeSpan(0, 1, 0));

			stage.AddSong(song);



		}

		[Test]
		public void Negative_AddSongToPerformer_Son()
        {
			Stage stage = new Stage();
			
			Assert.Throws<ArgumentNullException>(
				
				() => stage.AddSongToPerformer(null, "Sue Avramova" )
				
				);

			Assert.Throws<ArgumentNullException>(

				() => stage.AddSongToPerformer("Happy", null)

				);
		}

		[Test]
		public void Negative_AddSongToPerformer_Negative_GetPerformerName()
        {
			Stage stage = new Stage();

			Performer performer = new Performer("Sue", "Avramova", 31);
			Song song = new Song("Happy", new TimeSpan(0, 1, 15));
			stage.AddPerformer(performer);
			stage.AddSong(song);
			Assert.Throws<ArgumentException>(

				() => stage.AddSongToPerformer("Happy", "wrong")

				); ;


		}
		[Test]
		public void Negative_AddSongToPerformer_Negative_GetSongName()
		{
			Stage stage = new Stage();

			Performer performer = new Performer("Sue", "Avramova", 31);
			Song song = new Song("Happy", new TimeSpan(0, 1, 15));
			stage.AddPerformer(performer);
			stage.AddSong(song);
			Assert.Throws<ArgumentException>(

				() => stage.AddSongToPerformer("wrong", "Sue Avramova")

				); ;


		}
		[Test]
		public void Positive_AddSongToPerformer()
		{
			Stage stage = new Stage();

			Performer performer = new Performer("Sue", "Avramova", 31);
			Song song = new Song("Happy", new TimeSpan(0, 1, 15));
			stage.AddPerformer(performer);
			stage.AddSong(song);

			string result = stage.AddSongToPerformer("Happy", "Sue Avramova");

			Assert.AreEqual(1 ,performer.SongList.Count);
			Assert.AreSame(song, performer.SongList[0]);
			Assert.AreEqual(song, performer.SongList[0]);
			
			Assert.AreEqual($"Happy (01:15) will be performed by Sue Avramova", result);
			


		}
		[Test]

		public void Positive_Play()
        {

			Stage stage = new Stage();

			Performer performer = new Performer("Sue", "Avramova", 31);
			Song song = new Song("Happy", new TimeSpan(0, 1, 15));
			stage.AddPerformer(performer);
			stage.AddSong(song);
			stage.AddSongToPerformer("Happy", "Sue Avramova");
			string result = stage.Play();
			int count = stage.Performers.Sum(p => p.SongList.Count);

			Assert.AreEqual(1, count);

			Assert.AreEqual("1 performers played 1 songs", result);
		}
	}
}