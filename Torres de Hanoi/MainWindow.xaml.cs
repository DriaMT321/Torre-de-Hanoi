using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace Torres_de_Hanoi
{
    public partial class MainWindow : Window
    {
        private List<int> initialTower, auxiliaryTower, finalTower;
        private int steps;

        public MainWindow()
        {
            InitializeComponent();
            initialTower = new List<int>();
            auxiliaryTower = new List<int>();
            finalTower = new List<int>();
            steps = 0;
        }

        private void moveDisc(ListBox source, ListBox destination)
        {
            if (source.Items.Count > 0)
            {
                int disc = (int)source.Items[0];
                source.Items.RemoveAt(0);
                destination.Items.Insert(0, disc);
                steps++;
                Thread.Sleep(500); // Pausa para visualizar el movimiento
            }
        }

        private void hanoi(int n, ListBox initial, ListBox auxiliary, ListBox final)
        {
            if (n == 1)
            {
                moveDisc(initial, final);
            }
            else
            {
                hanoi(n - 1, initial, final, auxiliary);
                moveDisc(initial, final);
                hanoi(n - 1, auxiliary, initial, final);
            }
        }

        private void btnSolve_Click(object sender, RoutedEventArgs e)
        {
            int discs = int.Parse(txtDiscs.Text);
            populateTowers(discs);
            hanoi(discs, lbInitial, lbAuxiliary, lbFinal);
            MessageBox.Show($"El número total de pasos es: {steps}", "Torres de Hanoi");
        }

        private void populateTowers(int discs)
        {
            lbInitial.Items.Clear();
            lbAuxiliary.Items.Clear();
            lbFinal.Items.Clear();
            initialTower.Clear();
            auxiliaryTower.Clear();
            finalTower.Clear();

            for (int i = 1; i <= discs; i++)
            {
                initialTower.Add(i);
                lbInitial.Items.Add(i);
            }
        }
    }
}