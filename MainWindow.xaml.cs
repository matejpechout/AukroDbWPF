using AukroDbWPF.Model;
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

namespace AukroDbWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            
            InitializeComponent();
        }
        private void List_button_Click(object sender, RoutedEventArgs e)
        {   
            var db = new ApplicationDbContext();
            foreach (var a in db.Articles)
            {
                List_text.Text = (a.Id + ":" + a.Name + " " + a.Description + " " + a.Price);
                List_text.Text = "/n";
            }
        }
        private void Log_button_Click(object sender, RoutedEventArgs e)
        {
            var db = new ApplicationDbContext();
            string name = Name_text.Text;
            string password = Password_text.Text;
            LoginUser(db, name, password);
        }
        private void Reg_button_Click(object sender, RoutedEventArgs e)
        {
            var db = new ApplicationDbContext();
            string name = Name_text.Text;
                    string password = Password_text.Text;
                    AddUser(db, name, password);
        }
        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            var db = new ApplicationDbContext();
            string name = Name_art_text.Text;
            string description = Description_art_text.Text;
            int price = int.Parse(Price_art_text.Text);
            AddArticle(db, name, description, price);
        }
        static void ListArticles(ApplicationDbContext db)
        {
            foreach (var a in db.Articles)
            {
                string pomocna = (a.Id + ":" + a.Name + " " + a.Description + " " + a.Price);
            }
        }
        static void AddArticle(ApplicationDbContext db, string name, string description, int price)
        {
            string nname = name;
            string ddescription = description;
            int pprice = price;
            db.Articles.Add(new Article { Name = nname, Description = ddescription, Price = pprice });
            db.SaveChanges();
        }
        static void AddUser(ApplicationDbContext db, string name, string password)
        {
            string nname = name;
            string ppasword = password;
            
            foreach (var u in db.Users)
            {
                if (u.Name == nname)
                {

                    MessageBox.Show("Jméno již existuje");
                }
                else
                {
                    db.Users.Add(new User { Name = nname, Password = ppasword});
                    
                }
            }
            
            db.SaveChanges();
        }

        static void LoginUser(ApplicationDbContext db, string name, string password)
        {
            string nname = name;
            string ppasword = password;
            
            foreach(var u in db.Users)
            {
                if ((u.Name == nname) && (u.Password == ppasword))
                {
                   
                }
                else { MessageBox.Show("Špatné přihlašovací údaje");}
            }
        }

        
    }
}
