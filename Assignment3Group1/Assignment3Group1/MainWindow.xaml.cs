using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment3Group1
{
    //Assignment_3 done by:

    //Andrii Kosenko
    //301097272

    //Mucahit Aric 
    //301090476

    //Tereza Konstari 
    //301065539

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Fruits> fruits = new List<Fruits>
        {
            new Fruits{Name = "Mango", Color = "brown"},
            new Fruits{Name = "Pitaya", Color = "pink"},
            new Fruits{Name = "Watermelon", Color = "green"},
            new Fruits{Name = "Pomegranate", Color = "red"},
            new Fruits{Name = "Orange", Color = "orange"},
            new Fruits{Name = "Melon", Color = "yellow"},
            new Fruits{Name = "Apple", Color = "white"},
            new Fruits{Name = "Blueberry", Color = "blue"},
            new Fruits{Name = "Mangosteen", Color = "black"}
        };
         List<Planets> planets = new List<Planets>
        {
            new Planets{Name = "Mercury", Color = "brown"},
            new Planets{Name = "Venus", Color = "pink"},
            new Planets{Name = "Earth", Color = "green"},
            new Planets{Name = "Mars", Color = "red"},
            new Planets{Name = "Jupiter", Color = "orange"},
            new Planets{Name = "Saturn", Color = "yellow"},
            new Planets{Name = "Uranus", Color = "white"},
            new Planets{Name = "Neptune", Color = "blue"},
            new Planets{Name = "Pluto", Color = "black"}
        };

        public MainWindow()
        {
            InitializeComponent();
            using (var ctx = new Context())
            {
                var frt = new Fruits() { Name = "Mango", Color = "brown" };
                ctx.Fruits.AddRange(fruits);
                ctx.Planets.AddRange(planets);
                ctx.SaveChanges();
            }
        }

        private void cmbPlanet_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Planets planet in planets)
            {
                cmbPlanet.Items.Add(planet.Name);
            }
        }

        private void cmbFruit_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Fruits fruit in fruits)
            {
                cmbFruit.Items.Add(fruit.Name);
                fruit.SetFruitID();
            }
        }

        private void cmbPlanet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Planets planet in planets)
            {
                if (cmbPlanet.SelectedItem.ToString() == planet.Name)
                {
                    Planet.Items.Add(planet);
                }
                planet.SetPlanetID();
            }
        }

        private void cmbFruit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Fruits fruit in fruits)
            {
                if (cmbFruit.SelectedItem.ToString() == fruit.Name)
                {
                    Fruit.Items.Add(fruit);
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (Fruit.SelectedCells.Any())
            {
                Fruit.Items.Remove(Fruit.SelectedItem);
                Planet.UnselectAllCells();
                Fruit.UnselectAllCells();
            }

            if (Planet.SelectedCells.Any())
            {
                Planet.Items.Remove(Planet.SelectedItem);
                Fruit.UnselectAllCells();
                Planet.UnselectAllCells();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Fruit.Items.Clear();
            Planet.Items.Clear();
            Sellected.Items.Clear();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            foreach (Planets planet in planets)
            {
                if (planet == Planet.SelectedItem)
                {
                    Sellected.Items.Add(Planet.SelectedItem);
                    Fruit.UnselectAllCells();
                    Planet.UnselectAllCells();
                }
            }

            foreach (Fruits fruit in fruits)
            {
                if (fruit == Fruit.SelectedItem)
                {
                    Sellected.Items.Add(Fruit.SelectedItem);
                    Fruit.UnselectAllCells();
                    Planet.UnselectAllCells();
                }
            }
        }

        //copying fruit names from grid 1 to grid 3
        private void btnLINQProjectQS_Click(object sender, RoutedEventArgs e)
        {
            //var projectResult = from f in fruits
            //                     where f.Name == cmbFruit.SelectedItem.ToString()
            //                     select f.Name;
            Sellected.Items.Clear();

            var prjResult = fruits.Where(f => f.Name == cmbFruit.SelectedItem.ToString());
            Sellected.Items.Add(prjResult);
        }

        //filter by color in grid 3
        private void btnLINQFilterQS_Click(object sender, RoutedEventArgs e)
        {
            Sellected.Items.Clear();

            var filteredResult = from f in fruits
                                 join p in planets on f.Color equals p.Color
                                 where f.Name == cmbFruit.SelectedItem.ToString()
                                 select new { f.Name }; //or select f.Name;
            Sellected.Items.Add(filteredResult);
        }

        //order grid 3 fruits
        private void btnLINQOrderAscendingQS_Click(object sender, RoutedEventArgs e)
        {
            Sellected.Items.Clear();
            var ascendResult = from f in fruits
                               where f.Name == cmbFruit.SelectedItem.ToString()
                               orderby f.Name ascending
                               select f;
            Sellected.Items.Add(ascendResult);
        }

        //join grid 1 + grid 2
        private void btnLINQInnerJoinQS_Click(object sender, RoutedEventArgs e)
        {
            Sellected.Items.Clear();
            var innerJoinQuery = from f in fruits
                                 join p in planets on f.Color equals p.Color
                                 select new { f.Name, f.Color };
            Sellected.Items.Add(innerJoinQuery);

        }
    }
}
