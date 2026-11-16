namespace ParticleSwarmOptimization_SSI
{
    public partial class Form1 : Form
    {
        public int minPrzedzialZmiennosci = 0;
        public int maxPrzedzialZmiennosci = 100;
        public double r_inercji = 0.2; // wpływ bezwładu
        public double r_glob = 0.3; // przyciąganie do optimum globalnego
        public double r_lok = 0.3;  // przyciąganie do optimum lokalnego
        public double x_min = 0;
        public double max = 1;
        public int N = 4;
        public int iteracje_liczba = 30;
        public List<Osobnik> Populacja = new List<Osobnik>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void PetlaGLowna()
        {

        }
        public double Wartosc(double x1, double x2)
        {
            return Math.Sin(x1 * 0.05)+ Math.Sin(x2 * 0.05) + (0.4 * Math.Sin(x1 * 0.15) * Math.Sin(x1 * 0.15));
        }
        public double LosujLiczbeDouble(double minPrzedzialu, double maxPrzedzialu)
        {
            Random rand = new Random();
            return minPrzedzialu + rand.NextDouble() * (maxPrzedzialu - minPrzedzialu);
        }
        public double LosujLiczbeInt(int minPrzedzialu, int maxPrzedzialu)
        {
            Random rand = new Random();
            return rand.Next(minPrzedzialu, maxPrzedzialu);
        }
        public void StworzPopulacje(int N)
        {
            for(int i = 0; i < N; i++)
            {
                double x1 = LosujLiczbeInt(minPrzedzialZmiennosci, maxPrzedzialZmiennosci);
                double x2 = LosujLiczbeInt(minPrzedzialZmiennosci, maxPrzedzialZmiennosci);
                Osobnik Nowy = new Osobnik(x1, x2);
                Populacja.Add(Nowy);
            }
        }
    }
}
