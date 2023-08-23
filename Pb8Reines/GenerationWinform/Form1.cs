using Pb8Reines;
using System.Drawing;

namespace GenerationWinform
{
    public partial class Form1 : Form
    {
        private List<Generation> sesGeneration;
        private int indexGenerationObservee;
        private int generationSansProgres;
        public Form1()
        {
            InitializeComponent();
            sesGeneration = new List<Generation>();
            indexGenerationObservee = -1;
            generationSansProgres = 0;
        }

        private void panelDessin_Paint(object sender, PaintEventArgs e)
        {


            e.Graphics.Clear(Color.White);
            drawEchiquier(e.Graphics);

            if (sesGeneration.Count == 0 || indexGenerationObservee >= sesGeneration.Count())
                return;
            Generation saGen = sesGeneration[indexGenerationObservee];
            saGen.SortByFitness();
            drawIndividu(e.Graphics, saGen.Individus[0]);

        }

        private void drawIndividu(Graphics g, Individu i)
        {
            int cellW = panelDessin.Width / 8;
            int cellH = panelDessin.Height / 8;
            for (int x = 0; x < 8; x++)
            {
                int y = i.PositionReines[x];
                g.FillEllipse(new SolidBrush(Color.Red),
                        new Rectangle(x * cellW, y * cellH, cellW, cellH));
            }
        }
        private void drawEchiquier(Graphics g)
        {
            int cellW = panelDessin.Width / 8;
            int cellH = panelDessin.Height / 8;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    g.FillRectangle(new SolidBrush(((x + y) % 2 == 0 ? Color.Black : Color.White)),
                        new Rectangle(x * cellW, y * cellH, cellW, cellH));
                }
            }

        }

        private void buttonNouvelleGen_Click(object sender, EventArgs e)
        {
            sesGeneration.Clear();
            indexGenerationObservee = -1;
            generationSansProgres = 0;
            Generation gen;
            do {
                
                if (sesGeneration.Count() == 0)
                    gen = new Generation(10, 20);
                else
                    gen = new Generation(sesGeneration.Last());
                if (sesGeneration.Count() >= 1)
                {
                    int lastScore = sesGeneration.Last().SortByFitness()[0].Fitness();
                    gen.SortByFitness();

                    if (gen.Individus[0].Fitness() <= lastScore)
                    {
                        generationSansProgres++;
                    }
                    else
                    {
                        generationSansProgres = 0;
                    }
                    
                }
                sesGeneration.Add(gen);
                indexGenerationObservee++;
               
            } while (sesGeneration.Last().SortByFitness()[0].Fitness() < 56 || generationSansProgres > 1000);
            panelDessin.Refresh();
            labelProgres.Text = generationSansProgres.ToString();
            labelTotalGen.Text = sesGeneration.Count().ToString();
            labelScore.Text = gen.Individus[0].Fitness().ToString();
        }
    }
}