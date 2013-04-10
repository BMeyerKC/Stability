using System;
using System.Collections.Generic;
using System.Linq;

//  This will allow you to determine if an ongoing sampling 
//  has a stable average based on threshold 

namespace Stability
{
    public class Stable
    {

        public Stable()
        {
            SampleSize = 3;
            Threshold = 0.2;
        }

        public Stable(Stable stable)
        {
            SampleSize = stable.SampleSize;
            Threshold = stable.Threshold;
        }

        public int SampleSize { get; set; }

        public double Threshold { get; set; }

        public bool IsStable { get; set; }

        public List<double> Samples { get; private set; }

        public double StableAverage { get; private set; }

        public void AddSample(double sample)
        {
            if (Samples == null) Samples = new List<double>();

            Samples.Add(sample);

            if (Samples.Count > SampleSize)
            {
                //removes the oldest sample.
                Samples.RemoveAt(0);
            }

            CalculateStable();
        }

        private void CalculateStable()
        {
            //first get the total and the new average
            var total = 0.0;
            Samples.AsParallel().ForAll(s =>
            {
                total += s;
            });

            StableAverage = total / SampleSize;

            //now check to see if any samples are out of range of the threshold
            var pass = true;
            Samples.AsParallel().ForAll(s =>
            {
                if (Math.Abs(StableAverage - s) > Threshold) pass = false;
            });

            IsStable = (pass && (Samples.Count == SampleSize));
        }
    }
}
