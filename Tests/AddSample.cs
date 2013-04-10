using NUnit.Framework;
using Stability;

namespace Tests
{
    [TestFixture]
    public class AddSample
    {
        [Test]
        public void ChecksForNullSampleList()
        {
            var stable = new Stable();

            Assert.DoesNotThrow(() => stable.AddSample(123), "Adding Sample threw an error");
            Assert.IsNotNull(stable.Samples, "Samples is still null");
        }

        [Test]
        public void SampleAddedToNew()
        {
            var sample = 45.2;
            var stable = new Stable();

            stable.AddSample(sample);

            Assert.IsTrue(stable.Samples.Count > 0, "Sample not added to List.");
            Assert.AreEqual(sample, stable.Samples[0], "Sample not added to empty list");
        }

        [Test]
        public void SamplesDoesNotGetBiggerThanSampleSize()
        {
            var sampleSize = 2;
            var stable = new Stable(new Stable { SampleSize = sampleSize });

            stable.AddSample(23);
            stable.AddSample(65);
            stable.AddSample(123);

            Assert.AreEqual(sampleSize, stable.Samples.Count, "Samples count has exceeded sample size");
        }

        [Test]
        public void StableAverageUpdated()
        {
            var stable = new Stable();

            stable.AddSample(123);

            Assert.AreNotEqual(0, stable.StableAverage, "The Stable Average was not set.");
        }

        [Test]
        public void StableAverageIsCorrectWith3Values()
        {
            var average = 5;
            var diff = 2;
            var stable = new Stable();

            stable.AddSample(average + diff);
            stable.AddSample(average - diff);
            stable.AddSample(average);

            Assert.AreEqual(average, stable.StableAverage, "The Stable Average is not computing correctly with 3 values");
        }

        [Test]
        public void WillMarkAsStableWithDefaultThreshold()
        {
            var average = 5;
            var diff = .1;
            var stable = new Stable();

            stable.AddSample(average + diff);
            stable.AddSample(average - diff);
            stable.AddSample(average);

            Assert.IsTrue(stable.IsStable, "Not marked as stable and should have.");
        }

        [Test]
        public void WillMarkAsNotStableWithDefaultThreshold()
        {
            var average = 5;
            var diff = 2;
            var stable = new Stable();

            stable.AddSample(average + diff);
            stable.AddSample(average - diff);
            stable.AddSample(average);

            Assert.IsFalse(stable.IsStable, "Marked as stable and should not have.");
        }

        [Test]
        public void WillBecomeStableAndThenUnstableWithAnotherValue()
        {
            var average = 5;
            var diff = .1;
            var stable = new Stable();

            stable.AddSample(average + diff);
            stable.AddSample(average - diff);
            stable.AddSample(average);

            Assert.IsTrue(stable.IsStable, "Not marked as stable and should have.");

            stable.AddSample(average * 40);

            Assert.IsFalse(stable.IsStable, "Marked as stable and should not have.");

        }


    }
}