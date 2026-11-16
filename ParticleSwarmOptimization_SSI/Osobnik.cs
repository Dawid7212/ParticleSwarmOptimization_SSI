using System;
using System.Collections.Generic;
using System.Text;

namespace ParticleSwarmOptimization_SSI
{
    public class Osobnik
    {
        public double x1;
        public double x2;
        public double y;
        public Osobnik(double x1 = 0, double x2 = 0, double y = 0)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y = y;
        }
    }
}
