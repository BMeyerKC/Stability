using NUnit.Framework;
using Stability;

namespace Tests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void CanCreateDefault()
        {
            Assert.DoesNotThrow(() =>
            {
                new Stable();
            });
        }

        [Test]
        public void DefaultSampleSize()
        {
            var sampleSize = 3;

            var stable = new Stable();

            Assert.AreEqual(sampleSize, stable.SampleSize, "Sample Size default not set to " + sampleSize);
        }

        [Test]
        public void CanSetSampleSize()
        {
            //Arrange
            var sampleSize = 2;

            //Act
            var stable = new Stable(new Stable { SampleSize = sampleSize });

            //Assert
            Assert.AreEqual(sampleSize, stable.SampleSize, "Sample Size not set in constructor.");
        }

        [Test]
        public void DefaultThreshold()
        {
            var threshold = 0.2;

            var stable = new Stable();

            Assert.AreEqual(threshold, stable.Threshold, "Threshold default not set to " + threshold);
        }

        [Test]
        public void CanSetThreshold()
        {
            var threshold = 0.2;

            var stable = new Stable(new Stable { Threshold = threshold });

            Assert.AreEqual(threshold, stable.Threshold, "Threshold not set.");
        }

        [Test]
        public void DefaultIsStable()
        {
            var isStable = false;

            var stable = new Stable();

            Assert.AreEqual(isStable, stable.IsStable, "IsStable not defaulting to " + isStable);
        }
    }
}
