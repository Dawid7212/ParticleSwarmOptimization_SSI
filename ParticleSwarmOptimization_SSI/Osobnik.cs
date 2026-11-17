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
        public double x1_lok;
        public double x2_lok;
        public Osobnik(double x1 = 0, double x2 = 0, double y = 0, double x1_lok = 0, double x2_lok = 0)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y = y;
            this.x1_lok = x1_lok;
            this.x2_lok = x2_lok;
        }
        public void PrzypiszOptimaLokalne(double x1, double x2)
        {
            x1_lok = x1;
            x2_lok = x2;
        }
    }
}
