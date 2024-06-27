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

namespace PROG6221_POEPART3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Recipes> _recipes;

        public MainWindow()
        {
            InitializeComponent();
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            _recipes = new List<Recipes>
            {
                 new Recipes { Name = "Salad", Ingredients = new List<string> { "Lettuce", "Tomato" }, FoodGroup = "Vegetables", Calories = 150 },
                 new Recipes { Name = "Apple Pie", Ingredients = new List<string> { "Apple", "Flour" }, FoodGroup = "Fruits", Calories = 300 },
                 new Recipes { Name = "Banana Juice", Ingredients = new List<string> { "Banana", "Flour" }, FoodGroup = "Protein", Calories = 250 },
                 new Recipes { Name = "Coffee", Ingredients = new List<string> { "Fixed oil", "Caffeine" }, FoodGroup = "Grains", Calories = 200 },

            };

        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            string ingredient = txtIngredient.Text.ToLower();
            string foodGroup = (cmbFoodGroup.SelectedItem as ComboBoxItem)?.Content.ToString();
            bool isCaloriesValid = int.TryParse(txtMaxCalories.Text, out int maxCalories);

            var filteredRecipes = _recipes.Where(r =>
                (string.IsNullOrEmpty(ingredient) || r.Ingredients.Any(i => i.ToLower().Contains(ingredient))) &&
                (string.IsNullOrEmpty(foodGroup) || r.FoodGroup == foodGroup) &&
                (!isCaloriesValid || r.Calories <= maxCalories)).ToList();

            lstRecipe.ItemsSource = filteredRecipes;
            lstRecipe.DisplayMemberPath = "Name";
        }
    }
}