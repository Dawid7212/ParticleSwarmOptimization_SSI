using System.Windows.Forms.VisualStyles;

namespace ParticleSwarmOptimization_SSI
{
    public partial class Form1 : Form
    {
        public int minPrzedzialZmiennosci = 0;
        public int maxPrzedzialZmiennosci = 100;
        public Random rand = new Random();
        public double r_inercji = 0.2; // wpływ bezwładu
        public double r_glob = 0.3; // przyciąganie do optimum globalnego
        public double r_lok = 0.3;  // przyciąganie do optimum lokalnego
        public double x_min = 0;
        public double x_max = 1;
        public int N = 4;
        public int iteracje_liczba = 30;
        public double[,] Predkosc;
        public List<Osobnik> Populacja = new List<Osobnik>();
        public Osobnik x_glob = new Osobnik();
        public Form1()
        {
            InitializeComponent();
            Predkosc = new double[N, 2];
            StworzPopulacje(N);
            StworzTablicePredkosci(N, 2);
            PetlaGlowna();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void PetlaGlowna()
        {
            
            for(int iteracja = 0; iteracja < iteracje_liczba ; iteracja++)
            {
                //List<double> ListaWartosci = new List<double>();
                foreach(Osobnik sztuka in Populacja)
                {
                    sztuka.y = Wartosc(sztuka.x1, sztuka.x2);
                    //ListaWartosci.Add(sztuka.y);
                }
                if(iteracja == 0)
                {
                    double temp = double.NegativeInfinity;
                    int max = 0;
                    for (int j = 0; j<Populacja.Count; j++)
                    {
                        if (Populacja[j].y > temp)
                        {
                            max = j;
                            temp = Populacja[j].y; 
                        }
                    }
                    x_glob = new Osobnik(Populacja[max].x1, Populacja[max].x2, Populacja[max].y, Populacja[max].x1_lok, Populacja[max].x2_lok);
                }
                else
                {
                    for (int j = 0; j < Populacja.Count; j++)
                    {
                        if (Populacja[j].y > x_glob.y)
                        {
                            x_glob = new Osobnik(Populacja[j].x1, Populacja[j].x2, Populacja[j].y, Populacja[j].x1_lok, Populacja[j].x2_lok);
                        }
                    }
                }

                for (int j = 0;j < Populacja.Count; j++)
                {
                    double y_lok = Wartosc(Populacja[j].x1_lok, Populacja[j].x2_lok);
                    if (y_lok < Populacja[j].y)
                    {
                        Populacja[j].x1_lok = Populacja[j].x1;
                        Populacja[j].x2_lok = Populacja[j].x2;
                    }
                }

                for (int j = 0; j < Populacja.Count; j++)
                {
                    double rnd_glob = LosujLiczbeDouble(x_min, x_max);
                    double rnd_lok = LosujLiczbeDouble(x_min, x_max);
                    for (int i = 0; i < 2; i++)
                    {
                        if (i == 0)
                        {
                            Predkosc[j, i] = Predkosc[j, i] * r_inercji + (x_glob.x1 - Populacja[j].x1) * r_glob * rnd_glob + (Populacja[j].x1_lok - Populacja[j].x1) * r_lok * rnd_lok;
                            Populacja[j].x1 += Predkosc[j, i];
                            if (Populacja[j].x1 < minPrzedzialZmiennosci) { Populacja[j].x1 = minPrzedzialZmiennosci; }
                            if (Populacja[j].x1 > maxPrzedzialZmiennosci) { Populacja[j].x1 = maxPrzedzialZmiennosci; }
                        }
                        if (i == 1)
                        {
                            Predkosc[j, i] = Predkosc[j, i] * r_inercji + (x_glob.x2 - Populacja[j].x2) * r_glob * rnd_glob + (Populacja[j].x2_lok - Populacja[j].x2) * r_lok * rnd_lok;
                            Populacja[j].x2 += Predkosc[j, i];
                            if (Populacja[j].x2 < minPrzedzialZmiennosci) { Populacja[j].x2 = minPrzedzialZmiennosci; }
                            if (Populacja[j].x2 > maxPrzedzialZmiennosci) { Populacja[j].x2 = maxPrzedzialZmiennosci; }
                        }
                    }
                }
            }
        }
        public double Wartosc(double x1, double x2)
        {
            return Math.Sin(x1 * 0.05)+ Math.Sin(x2 * 0.05) + (0.4 * Math.Sin(x1 * 0.15) * Math.Sin(x2 * 0.15));
        }
        public double LosujLiczbeDouble(double minPrzedzialu, double maxPrzedzialu)
        {
            return minPrzedzialu + rand.NextDouble() * (maxPrzedzialu - minPrzedzialu);
        }
        public double LosujLiczbeInt(int minPrzedzialu, int maxPrzedzialu)
        {
            return rand.Next(minPrzedzialu, maxPrzedzialu);
        }
        public void StworzPopulacje(int N)
        {
            for(int i = 0; i < N; i++)
            {
                double x1 = LosujLiczbeDouble(minPrzedzialZmiennosci, maxPrzedzialZmiennosci);
                double x2 = LosujLiczbeDouble(minPrzedzialZmiennosci, maxPrzedzialZmiennosci);
                Osobnik Nowy = new Osobnik(x1, x2);
                Nowy.PrzypiszOptimaLokalne(x1, x2);
                Populacja.Add(Nowy);
            }
        }
        public void StworzTablicePredkosci(int N, int n)
        {
            for (int i = 0;i < N; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Predkosc[i, j] = 0;
                }
            }
        }
    }
}
