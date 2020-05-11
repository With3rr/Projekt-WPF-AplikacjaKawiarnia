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
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;

namespace ProjektSzkolenieTechniczne
{



    /// <summary> Główna klasa aplikacji w której to ciele okręslona jest metoda Main ,zmienne,kolekcje bądź metody które bedą odpowiadały za funkcjonalności poszczególnych elementów aplikacji  </summary>
   
    public partial class MainWindow : Window
    {
        /// <summary>Reprezentuje listę typu ObservableCollection która przechowuje obiekty Oferty dla typu oferowanych produktów w aplikacji "ForToday" </summary>
        private ObservableCollection<Oferty> ForToday = null;

        /// <summary>Reprezentuje listę typu ObservableCollection która przechowuje obiekty Oferty dla typu oferowanych produktów w aplikacji "Foods" </summary>
        private ObservableCollection<Oferty> Foods = null;

        /// <summary>Reprezentuje listę typu ObservableCollection która przechowuje obiekty Oferty dla typu oferowanych produktów w aplikacji "Drinks" </summary>
        private ObservableCollection<Oferty> Drinks = null;

        /// <summary>Reprezentuje listę typu ObservableCollection która przechowuje obiekty Oferty dla typu oferowanych produktów w aplikacji "Deserts" </summary>
        private ObservableCollection<Oferty> Deserts = null;

        /// <summary>Reprezentuje listę typu ObservableCollection która przechowuje obiekty Oferty dla typu oferowanych produktów w aplikacji "Sweets" </summary>
        private ObservableCollection<Oferty> Sweets = null;

        /// <summary>Reprezentuje listę typu List określającą listę przycisków typu Button</summary>
        private List<Button> przysiski = null;

        private int Licznikproduktu = 1;

        /// <summary>Reprezentuje listę typu ObservableCollection która przechowuje obiekty tylu CollectionView która to odpowiadać będzie za przechowywanie widoków które na których będą w dalszym etapie wykonywane operacjie filtrowania danych </summary>
        private ObservableCollection<CollectionView> widoki = null;

        /// <summary>Reprezentuje listę typu ObservableCollection która przechowuje obiekty(zamówione produkty) klasy ProduktyZamowione </summary>
        private ObservableCollection<ProduktyZamowione> zamowioneprod = null;

        private CalkowitaCena cenazamowienia = null;

        private bool CzyDowoz;

        private DaneKoncowe daneKonca;

        private List<Grid> gridyProd = null;

        /// <summary>Reprezentuje zmienną która będzie odnosić się do bazy danych </summary>
        private BazaZamowienEntities bazadanych = null;

        private int licznikZamowien;

        private string sposobPlatnosci = "";
        /// <summary>Metoda main apliacji,to od niej zaczyna się wykonywanie </summary>
        public MainWindow()
        {
            bazadanych = new BazaZamowienEntities();
            daneKonca = new DaneKoncowe();

            this.MaxHeight = 900.00;
            this.MaxWidth = 600.00;
            this.MinHeight = 900.00;
            this.MinWidth = 600.00;


            InitializeComponent();
            przysiski = new List<Button>();
            przysiski.Add(leftbt0);
            przysiski.Add(leftbt1);
            przysiski.Add(leftbt2);
            przysiski.Add(leftbt3);
            przysiski.Add(leftbt4);
            przysiski.Add(leftbt5);
            przysiski.Add(leftbt6);

            gridyProd = new List<Grid>();
            gridyProd.Add(gridPanel1);
            gridyProd.Add(gridPanel2);
            gridyProd.Add(gridPanel3);
            gridyProd.Add(gridPanel4);
            gridyProd.Add(gridPanel5);
            gridyProd.Add(gridPanel6);
            gridyProd.Add(gridPanel7);

            cenazamowienia = new CalkowitaCena();
            this.cenaMAxgrid.DataContext = cenazamowienia;


            licznikZamowien = bazadanych.ZamowieniaDetail.Count() + 1;






            inicjalizacjaProduktow();

            //bazadanych.KartaPlatniczaVisa.Add(new  KartaPlatniczaVisa { Imie = "Marcin", Nazwisko = "Babol",  Nr_karty = "345495948437",  Kod = "319", Stan = 2800 , Id=1 });
            //bazadanych.SaveChanges();
        }

        /// <summary>Inicjalizuje,dodaje poszczególne widoki kolejnych dataGrid i dodaje je do listy co pozowli na łatwy dostęp do nich </summary>
        public void inicjalizacjaWidokow()
        {
            widoki = new ObservableCollection<CollectionView>();
            widoki.Add((CollectionView)CollectionViewSource.GetDefaultView(Item1.ItemsSource));
            widoki.Add((CollectionView)CollectionViewSource.GetDefaultView(Item2.ItemsSource));
            widoki.Add((CollectionView)CollectionViewSource.GetDefaultView(Item3.ItemsSource));
            widoki.Add((CollectionView)CollectionViewSource.GetDefaultView(Item4.ItemsSource));
            widoki.Add((CollectionView)CollectionViewSource.GetDefaultView(Item5.ItemsSource));
            

            


        }
        /// <summary>Jest to metoda która pozwala na zresetowanie poprzednio wykorzystywanych zmiennych,będzie to konieczne podcza dokonania zakupu w aplikacji i chęci ponownego złożenia zamówienia </summary>
        private void resetowanie()
        {
            Licznikproduktu = 1;
            cenazamowienia.Zeruj();
            zamowioneprod.Clear();
            daneKonca.Usun();
            licznikZamowien = bazadanych.ZamowieniaDetail.Count() + 1;

            rb1.IsChecked = false;
            rb2.IsChecked = false;

            wypelnienie1.Text = string.Empty;
            wypelnienie2.Text = string.Empty;
            wypelnienie3.Text = string.Empty;
            wypelnienie4.Text = string.Empty;
            wypelnienie5.Text = string.Empty;
            wypelnienie6.Text = string.Empty;
            wypelnienie7.Text = string.Empty;

            ImieKarta.Text= String.Empty;
            NazwiskoKarta.Text = String.Empty;
            Nrkarta.Text = String.Empty;
            KodKarta.Text = String.Empty;

            sposobPlatnosci = "";
            sposobPlaceniaVisa.Visibility = Visibility.Collapsed;


            wypelnienie1.BorderBrush = Brushes.Black;
            wypelnienie2.BorderBrush = Brushes.Black;
            wypelnienie3.BorderBrush = Brushes.Black;
            wypelnienie4.BorderBrush = Brushes.Black;
            wypelnienie5.BorderBrush = Brushes.Black;
            wypelnienie6.BorderBrush = Brushes.Black;
            wypelnienie7.BorderBrush = Brushes.Black;
            bladmetodyPlatnosci.Visibility = Visibility.Collapsed;
            niepoprawnakarta.Visibility = Visibility.Collapsed;



        }
        ///<summary>Metoda ta słozy do inicjalizacji podruktów które będą wchodziły w skład oferty sklepu(kolejno dodawanie produktów do list) </summary>
        ///<remarks> Poza powyższym metoda ta okresla również własciwosć ItemsSource dla poszczegółnych dataGrid czyli określanie DataKontext</remarks>
        public void inicjalizacjaProduktow()
        {
            string sciezka = "pack://application:,,,/Zdjecia/";
            

            ForToday = new ObservableCollection<Oferty>();
            ForToday.Add(new Oferty("Sandwich", 2.50, new Uri(sciezka + "For today/sandwich.png")));
            ForToday[0].Opis = "Mix the beef, cumin, paprika, salt and plenty of freshly ground black pepper together in a bowl. Divide the mince mixture into 8 portions and press each portion firmly onto flat skewers, each one around 10–12cm/4–4½in long. Place a non-stick griddle pan over a high heat and brush with a little oil.";
            ForToday[0].Skladniki = "Beef,Cumin,Paprika,Salt";
            ForToday[0].Waga = "0.7";
            
            ForToday.Add(new Oferty("Egg+becon", 4.00, new Uri(sciezka + "For today/becon.png")));
            ForToday.Add(new Oferty("Vburger", 5.00, new Uri(sciezka + "For today/burger.png")));
            ForToday.Add(new Oferty("Sushi", 5.70, new Uri(sciezka + "For today/sushi.png")));

            Foods = new ObservableCollection<Oferty>();
            Foods.Add(new Oferty("Burger", 3.50, new Uri(sciezka + "Foods/burger.png")));
           
            Foods.Add(new Oferty("Shashlik", 4.30, new Uri(sciezka + "Foods/szaszlyk.png")));
            Foods.Add(new Oferty("Pizza", 7.20, new Uri(sciezka + "Foods/pizza.png")));
            Foods.Add(new Oferty("Chicken", 6.70, new Uri(sciezka + "Foods/meat.png")));
            Foods.Add(new Oferty("Kebab", 6.20, new Uri(sciezka + "Foods/keb.png")));
            Foods.Add(new Oferty("Fries", 2.70, new Uri(sciezka + "Foods/food.png")));
            Foods.Add(new Oferty("Fish", 7.15, new Uri(sciezka + "Foods/f.png")));
            Foods.Add(new Oferty("Eggs", 3.20, new Uri(sciezka + "Foods/egs.png")));
            Foods[0].Opis = "Shashlik was originally made of lamb, but nowadays it is also made of pork, beef, or venison, depending on local preferences and religious observances. The skewers are either threaded with meat only, or with alternating pieces of meat, fat, and vegetables, such as bell pepper, onion, mushroom and tomato.";
            Foods[0].Skladniki = "Beef,Soose,Paprika,Ketchup";
            Foods[0].Waga = "0.2";
            

            Drinks = new ObservableCollection<Oferty>();
            Drinks.Add(new Oferty("Wine", 2.99, new Uri(sciezka + "Drinks/wine.png")));
            Drinks.Add(new Oferty("Beer", 2.30, new Uri(sciezka + "Drinks/beer.png")));
            Drinks.Add(new Oferty("Coctail", 3.27, new Uri(sciezka + "Drinks/cocktail.png")));
            Drinks.Add(new Oferty("Coffee", 2.69, new Uri(sciezka + "Drinks/coffee-cup.png")));
            Drinks.Add(new Oferty("Tea", 2.20, new Uri(sciezka + "Drinks/coffee.png")));
            Drinks.Add(new Oferty("Juice", 1.70, new Uri(sciezka + "Drinks/juice.png")));
            Drinks.Add(new Oferty("Whisky", 6.80, new Uri(sciezka + "Drinks/whisky.png")));
            Drinks.Add(new Oferty("Cola", 2.89, new Uri(sciezka + "Drinks/soda.png")));

            Deserts = new ObservableCollection<Oferty>();
            Deserts.Add(new Oferty("Icecream", 4.76, new Uri(sciezka + "Deserts/ice-creams.png")));
            Deserts.Add(new Oferty("Chocolater", 3.00, new Uri(sciezka + "Deserts/cake1.png")));
            Deserts.Add(new Oferty("Apple pie", 4.60, new Uri(sciezka + "Deserts/pie.png")));
            Deserts.Add(new Oferty("Carmel cake", 7.30, new Uri(sciezka + "Deserts/cake2.png")));
            Deserts.Add(new Oferty("Bacake", 4.20, new Uri(sciezka + "Deserts/cake.png")));
            Deserts.Add(new Oferty("Biscuits", 3.30, new Uri(sciezka + "Deserts/bisc.png")));


            Sweets = new ObservableCollection<Oferty>();
            Sweets.Add(new Oferty("Chocolate", 2.65, new Uri(sciezka + "Sweets/chocolate.png")));
            Sweets.Add(new Oferty("Candies", 2.00, new Uri(sciezka + "Sweets/candy.png")));
            Sweets.Add(new Oferty("Donut", 4.10, new Uri(sciezka + "Sweets/donut.png")));
            Sweets.Add(new Oferty("Lolipop", 1.70, new Uri(sciezka + "Sweets/lollipop.png")));


            Item1.ItemsSource = ForToday;
            Item2.ItemsSource = Foods;
            Item3.ItemsSource = Drinks;
            Item4.ItemsSource = Deserts;
            Item5.ItemsSource = Sweets;

            zamowioneprod = new ObservableCollection<ProduktyZamowione>();
            datagridbasket.ItemsSource = zamowioneprod;





            inicjalizacjaWidokow();
            Filtrowanie();


            


        }

        /// <summary>Metoda ta odpowiada za dodawanie do kazdego z widoków określonego filtramprzypisanie delegata do własciwości widoku  </summary>
        ///<remarks>Dodawanie polega na ogkreśleniu delegata(w tym przypadku "FiltrUzytkownika" i dołączanie go kolejno do widoków,Widoki które reprezentują poszczególne DataGrid(ich filtr) jest określony dla każego
        ///w identyczny sposób wiec filtrowanie to będzie widocze w każym z widoków(w każdym DataGrid)</remarks>
        public void Filtrowanie()
        {

            for (int i = 0; i <=4; i++)
            {
                widoki[i].Filter = FiltrUzytkownika;

            }



            

        }

        /// <summary>Metoda ta będzie przypisywana jako delegat do widoków  </summary>
        ///<remarks>Metoda przyjmuje jeden obiekt typu object który symbolizuje jeden rekord(item) w liscie obiektów dataGrid oraz zwraza wartość bool która symbolizuje czy dany obiekt(jego własciwości pasują do określonego filtra)</remarks>
        ///<returns> Zwraca wartość bool jako wynik określenia czy dany obiekt jest zgodny z określonym filtrem</returns>
        /// <param name="item">objekt przekazywany będący Kolejno obiektem z DataGrid</param>
        private bool FiltrUzytkownika(object item)
        {
            if (tbFilter.Text==string.Empty || (item as Oferty).Nazwa.Contains(tbFilter.Text))
            {
                return true;
            }
            else
            {
                return false;
            }





        }
        
        ///<summary>
        ///Metoda zmieniająca kolory przycisków
        /// </summary>
        ///<remarks>Metoda ta odpowiada za nadawanie odpowiedniego BorderThickness dla konkretnego przyciusku co zmnienia sie w zależnosci jego wyboru</remarks>      
        /// <param name="a">przyjmuje prametr który będzie wykożystwyany do wskazywania nato króty przycisk jest wciśnięty</param>
        private void przyciskkolor(int a)
        {
            

            for (int i = 0; i <= 6; i++)
            {
                if (i != a)
                {


                    przysiski[i].BorderThickness = new Thickness(1);

                }
                else
                {
                    przysiski[i].BorderThickness = new Thickness(4);

                }





            }

        }
        ///<summary>
        ///Zmian wyświetlania konkretnego panelu (przełączanie pomiędzy tabelami)
        /// </summary>
        ///<remarks>Metoda ta odpowiada za wyświtlanie określonego Gridu z listy gridyProd co odpowiada przełączanie pomiędzy róznymi tabelami w których znajdują się różne type jedzeń i napojów
        ///metoda ta również określa czy wyświetlany jest TextBox który będzie odpowadał za wyświetlanie treści ,dzieje się to również w zależnosci od tego który z przycisków został wciścięty </remarks>

        /// <param name="a">przyjmuje prametr który będzie wykożystwyany do wskazywania nato króty przycisk wyboru typu dostarczanego produktu  jest wciśnięty(Drinks,Foods)</param>
        /// <example>
        /// <code>
        /// wyswietlanie(1);
        /// panelDoFiltrowania.Visibility = Visibility.Visible;
        /// gridyProd[0].Visibility = Visibility.Collapsed;
        /// gridyProd[1].Visibility = Visibility.Visible;
        /// gridyProd[2].Visibility = Visibility.Collapsed;
        /// gridyProd[3].Visibility = Visibility.Collapsed;
        /// gridyProd[4].Visibility = Visibility.Collapsed;
        /// gridyProd[5].Visibility = Visibility.Collapsed;
        /// gridyProd[6].Visibility = Visibility.Collapsed;
        /// 
        /// 
        /// 
        /// 
        /// </code>
        /// </example>

        private void wyswietlanie(int a)
        {
            spDodwanieProduktu.Visibility = Visibility.Collapsed;
            if(a!=5)
            {
                panelDoFiltrowania.Visibility = Visibility.Visible;
            }
            else
            {
                panelDoFiltrowania.Visibility = Visibility.Collapsed;

            }


            for (int i = 0; i < gridyProd.Count; i++)
            {
                if (i != a)
                {


                    gridyProd[i].Visibility = Visibility.Collapsed;

                }
                else
                {
                    gridyProd[i].Visibility = Visibility.Visible;

                }





            }

        }

        /// <summary>
        /// Zmiana wyświetlania buttonów
        /// </summary>
        ///<remarks>Jest to event(zdarzenie) które reaguje na wciśniętci klawisza z menu wyboru typów produktów np. Food,Drinks ,w ciele wywoływana jest metoda przyciskkolor i wyswietlanie oraz określany jest licznik produktu jako zmienna która służy za mechanizm komunikowania która z tabel opisująca produkty jest teraz wybrana </remarks>       
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leftbt0_Click(object sender, RoutedEventArgs e)
        {
            
            przyciskkolor(0);
            wyswietlanie(0);
            Licznikproduktu = 1;

        }

        /// <summary>
        /// Jest to event(zdarzenie) które reaguje na wciśnięcie  klawisza z menu wyboru typów produktów np. Food,Drinks
        /// </summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param>
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>
        private void leftbt1_Click(object sender, RoutedEventArgs e)
        {
            przyciskkolor(1);
            wyswietlanie(1);
            Licznikproduktu = 2;

        }


        /// <summary>
        /// Jest to event(zdarzenie) które reaguje na wciśnięcie  klawisza z menu wyboru typów produktów np. Food,Drinks
        /// </summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param>
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>
        private void leftbt2_Click(object sender, RoutedEventArgs e)
        {
            przyciskkolor(2);
            wyswietlanie(2);
            Licznikproduktu = 3;

        }


        /// <summary>
        /// Jest to event(zdarzenie) które reaguje na wciśnięcie  klawisza z menu wyboru typów produktów np. Food,Drinks
        /// </summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param>
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>
        private void leftbt3_Click(object sender, RoutedEventArgs e)
        {
            przyciskkolor(3);
            wyswietlanie(3);
            Licznikproduktu = 4;

        }



        /// <summary>
        /// Jest to event(zdarzenie) które reaguje na wciśnięcie  klawisza z menu wyboru typów produktów np. Food,Drinks
        /// </summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param>
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>
        private void leftbt4_Click(object sender, RoutedEventArgs e)
        {
            przyciskkolor(4);
            wyswietlanie(4);
            Licznikproduktu = 5;

        }



        /// <summary>
        /// Jest to event(zdarzenie) które reaguje na wciśnięcie  klawisza z menu wyboru typów produktów np. Food,Drinks
        /// </summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param>
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>
        private void leftbt5_Click(object sender, RoutedEventArgs e)
        {
            przyciskkolor(5);
            wyswietlanie(5);
            ObliczanieTotala();

            panelDoFiltrowania.Visibility = Visibility.Collapsed;





        }

      
        
        /// <summary>
        /// Metoda która ma za zadanie sumowania cen poszczegulnych zamówionych produktów i przechowaniu tej wartosci w włąsciwości obiektu klasy CalkowitaCena
        /// </summary>
        public void ObliczanieTotala()
        {
            cenazamowienia.CenaCalkowita = 0;

            for (int i = 0; i < zamowioneprod.Count; i++)
            {
                cenazamowienia.CenaCalkowita += zamowioneprod[i].CenaAll;

            }

        }





        /// <summary>
        /// Jest to event(zdarzenie) które reaguje na wciśniętci klawisza z menu wyboru typów produktów np. Food,Drinks
        /// </summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param>
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>
        private void leftbt6_Click(object sender, RoutedEventArgs e)
        {
            przyciskkolor(6);
            wyswietlanie(6);


        }


        ///<summary>wyswietlanie Gridu (Visibility.Visible) do dowania produktu do koszyka</summary>
        ///<remarks> wyswietlany jest tu grid dzięki któremu możemy zakupic dany produkt określając dodatkowo liczbą sztuk którą chcemy zakupić ("domyślnie 1") </remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void buyProductbutton_Click(object sender, RoutedEventArgs e)
        {

            spDodwanieProduktu.Visibility = Visibility.Visible;
            wpisywanieIloscitb.Text = "1";


        }


        ///<summary>Metoda ta odpowiada za mechanikę dodawania produktu do koszyka</summary>
        ///<remarks>Działanie tej  metody polega na poszczególnych krokach 1.sprawdzanie czy wprowadzona ilość produktów jest liczbą ora czy jest ona większa od 0 
        ///2. określanie na podstawie licznika produktu z którego DataGrid będzie pobierany produkt.Zmienna czy prawda określona w kodzie określa czy dany produkt już został zamówiony i w zaleznosci od tej decyzji porgram zadziała inaczej</remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void EnterProduct_Click(object sender, RoutedEventArgs e)
        {
            int ilosc=0;

            bool czy = Int32.TryParse(wpisywanieIloscitb.Text, out ilosc);
            
            if(czy==true && ilosc>0)
            {
                zlaliczba.Visibility = Visibility.Collapsed;

                double CenaAll = 0;
                if(Licznikproduktu==1)
                {
                    CenaAll = (Item1.SelectedItem as Oferty).Cena * Convert.ToInt32(wpisywanieIloscitb.Text);
                    bool czyPrawda = false;
                    for (int i = 0; i < zamowioneprod.Count; i++)
                    {
                        if(zamowioneprod[i].Nazwa==(Item1.SelectedItem as Oferty).Nazwa)
                        {
                            zamowioneprod[i].Ilosc += ilosc;
                            zamowioneprod[i].CenaAll = zamowioneprod[i].Cena * zamowioneprod[i].Ilosc;



                            czyPrawda =true;
                        }

                    }
                    spDodwanieProduktu.Visibility = Visibility.Collapsed;
                    if (czyPrawda==false)
                    {
                        zamowioneprod.Add(new ProduktyZamowione((Item1.SelectedItem as Oferty).Nazwa, (Item1.SelectedItem as Oferty).Cena, (Item1.SelectedItem as Oferty).Zdjecie, ilosc, CenaAll));
                        spDodwanieProduktu.Visibility = Visibility.Collapsed;

                    }
                   

                }
                else if(Licznikproduktu == 2)
                {
                    CenaAll = (Item2.SelectedItem as Oferty).Cena * Convert.ToInt32(wpisywanieIloscitb.Text);

                    bool czyPrawda = false;
                    for (int i = 0; i < zamowioneprod.Count; i++)
                    {
                        if (zamowioneprod[i].Nazwa == (Item2.SelectedItem as Oferty).Nazwa)
                        {
                            zamowioneprod[i].Ilosc += ilosc;
                            zamowioneprod[i].CenaAll = zamowioneprod[i].Cena * zamowioneprod[i].Ilosc;



                            czyPrawda = true;
                        }

                    }
                    spDodwanieProduktu.Visibility = Visibility.Collapsed;
                    if(czyPrawda==false)
                    {
                        zamowioneprod.Add(new ProduktyZamowione((Item2.SelectedItem as Oferty).Nazwa, (Item2.SelectedItem as Oferty).Cena, (Item2.SelectedItem as Oferty).Zdjecie, ilosc, CenaAll));
                        spDodwanieProduktu.Visibility = Visibility.Collapsed;

                    }

                   



                }
                else if (Licznikproduktu == 3)
                {
                    CenaAll = (Item3.SelectedItem as Oferty).Cena * Convert.ToInt32(wpisywanieIloscitb.Text);
                    bool czyPrawda = false;
                    for (int i = 0; i < zamowioneprod.Count; i++)
                    {
                        if (zamowioneprod[i].Nazwa == (Item3.SelectedItem as Oferty).Nazwa)
                        {
                            zamowioneprod[i].Ilosc += ilosc;
                            zamowioneprod[i].CenaAll = zamowioneprod[i].Cena * zamowioneprod[i].Ilosc;



                            czyPrawda = true;
                        }

                    }
                    spDodwanieProduktu.Visibility = Visibility.Collapsed;
                    if(czyPrawda==false)
                    {
                        zamowioneprod.Add(new ProduktyZamowione((Item3.SelectedItem as Oferty).Nazwa, (Item3.SelectedItem as Oferty).Cena, (Item3.SelectedItem as Oferty).Zdjecie, ilosc, CenaAll));
                        spDodwanieProduktu.Visibility = Visibility.Collapsed;

                    }

                   


                }
                else if (Licznikproduktu == 4)
                {
                    CenaAll = (Item4.SelectedItem as Oferty).Cena * Convert.ToInt32(wpisywanieIloscitb.Text);
                    bool czyPrawda = false;
                    for (int i = 0; i < zamowioneprod.Count; i++)
                    {
                        if (zamowioneprod[i].Nazwa == (Item4.SelectedItem as Oferty).Nazwa)
                        {
                            zamowioneprod[i].Ilosc += ilosc;
                            zamowioneprod[i].CenaAll = zamowioneprod[i].Cena * zamowioneprod[i].Ilosc;



                            czyPrawda = true;
                        }

                    }
                    spDodwanieProduktu.Visibility = Visibility.Collapsed;


                    if(czyPrawda==false)
                    {
                        zamowioneprod.Add(new ProduktyZamowione((Item4.SelectedItem as Oferty).Nazwa, (Item4.SelectedItem as Oferty).Cena, (Item4.SelectedItem as Oferty).Zdjecie, ilosc, CenaAll));
                        spDodwanieProduktu.Visibility = Visibility.Collapsed;

                    }
                   


                }
                else if (Licznikproduktu == 5)
                {
                    CenaAll = (Item5.SelectedItem as Oferty).Cena * Convert.ToInt32(wpisywanieIloscitb.Text);

                    bool czyPrawda = false;
                    for (int i = 0; i < zamowioneprod.Count; i++)
                    {
                        if (zamowioneprod[i].Nazwa == (Item5.SelectedItem as Oferty).Nazwa)
                        {
                            zamowioneprod[i].Ilosc += ilosc;
                            zamowioneprod[i].CenaAll = zamowioneprod[i].Cena * zamowioneprod[i].Ilosc;



                            czyPrawda = true;
                        }

                    }
                    spDodwanieProduktu.Visibility = Visibility.Collapsed;
                    if(czyPrawda==false)
                    {
                        zamowioneprod.Add(new ProduktyZamowione((Item5.SelectedItem as Oferty).Nazwa, (Item5.SelectedItem as Oferty).Cena, (Item5.SelectedItem as Oferty).Zdjecie, ilosc, CenaAll));
                        spDodwanieProduktu.Visibility = Visibility.Collapsed;


                    }



                }
                CollectionViewSource.GetDefaultView(datagridbasket.ItemsSource).Refresh();



            }
            else
            {
                zlaliczba.Visibility = Visibility.Visible;
            }
           







        }


        ///<summary>wyswietlanie Gridu (Visibility.Visible) do dowania produktu do koszyka</summary>
        ///<remarks> wyswietlany jest tu grid dzięki któremu możemy zakupic dany produkt określając dodatkowo liczbą sztuk którą chcemy zakupić ("domyślnie 1") </remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void buyProductbutton2_Click(object sender, RoutedEventArgs e)
        {
            spDodwanieProduktu.Visibility = Visibility.Visible;
            wpisywanieIloscitb.Text = "1";


        }

        ///<summary>wyswietlanie Gridu (Visibility.Visible) do dowania produktu do koszyka</summary>
        ///<remarks> wyswietlany jest tu grid dzięki któremu możemy zakupic dany produkt określając dodatkowo liczbą sztuk którą chcemy zakupić ("domyślnie 1") </remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void buyProductbutton3_Click(object sender, RoutedEventArgs e)
        {
            spDodwanieProduktu.Visibility = Visibility.Visible;
            wpisywanieIloscitb.Text = "1";

        }


        ///<summary>wyswietlanie Gridu (Visibility.Visible) do dowania produktu do koszyka</summary>
        ///<remarks> wyswietlany jest tu grid dzięki któremu możemy zakupic dany produkt określając dodatkowo liczbą sztuk którą chcemy zakupić ("domyślnie 1") </remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void buyProductbutton4_Click(object sender, RoutedEventArgs e)
        {
            spDodwanieProduktu.Visibility = Visibility.Visible;
            wpisywanieIloscitb.Text = "1";

        }

        ///<summary>wyswietlanie Gridu (Visibility.Visible) do dowania produktu do koszyka</summary>
        ///<remarks> wyswietlany jest tu grid dzięki któremu możemy zakupic dany produkt określając dodatkowo liczbą sztuk którą chcemy zakupić ("domyślnie 1") </remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void buyProductbutton5_Click(object sender, RoutedEventArgs e)
        {
            spDodwanieProduktu.Visibility = Visibility.Visible;
            wpisywanieIloscitb.Text = "1";

        }

        /// <summary>
        /// Zasłanianie panelu
        /// </summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Item1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            spDodwanieProduktu.Visibility = Visibility.Collapsed;
        }


        ///<summary>Event umożliwiająca usuwanie kontretnych zamówionych produktów z koszyka</summary>
        ///<remarks>Działanie tej metody polega na wybraniu z datagrid.basket okreslonego produktu oraz usunięcie ko z listy zamowioneprod ,dodatkowo wywołana zostaje metoda która Oblicza od nowa całkowitą wartość zamówienia (ObliczanieTotala();) </remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void usuwanieProdKosz_Click(object sender, RoutedEventArgs e)
        {
            zamowioneprod.Remove(datagridbasket.SelectedItem as ProduktyZamowione);
            ObliczanieTotala();

        }


        ///<summary>Metoda umożliwiająca usuwanie kontretnych całego zamówienia z koszyka</summary>   
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(zamowioneprod.Count>=1)
            {
                potwiedzenieUsunieciaAll.Visibility = Visibility.Visible;

            }
            
        }


        ///<summary>Event potwiedzająca usunięcie wszystkich przedmiotów z koszyka zakupów</summary>   
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            zamowioneprod.Clear();
            ObliczanieTotala();
            potwiedzenieUsunieciaAll.Visibility = Visibility.Collapsed;
        }


        ///<summary>Event zasłaniająza potwierdzenie usunięcia</summary>   
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            potwiedzenieUsunieciaAll.Visibility = Visibility.Collapsed;

        }


        ///<summary>Event zasłaniająza potwierdzenie usunięcia(przycisk wyłącz)</summary>   
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            potwiedzenieUsunieciaAll.Visibility = Visibility.Collapsed;
        }


        ///<summary>Wykonanie procesu</summary>   
        ///<remarks>Event ta zawiera w swoim ciele wywołanie metody Start z klasy Process.Działanie polega na wprowadzeniu odpowiedniego linku do strony w argumencie metody</remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com");
        }


        ///<summary>Wykonanie procesu</summary>   
        ///<remarks>Event ta zawiera w swoim ciele wywołanie metody Start z klasy Process.Działanie polega na wprowadzeniu odpowiedniego linku do strony w argumencie metody</remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
           

            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=q9DtOKhZ2AY");
        }


        ///<summary>Wykonanie procesu</summary>   
        ///<remarks>Event ta zawiera w swoim ciele wywołanie metody Start z klasy Process.Działanie polega na wprowadzeniu odpowiedniego linku do strony w argumencie metody</remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com");

        }

        ///<summary>Zamknięcie aplikacji</summary>
        ///<remarks>Event wywołująca w swoim ciele metodę mods dla obecnego obiektu co spowoduje zamknięcie aplikacji</remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        ///<summary>Wywołanie odświerzenia widoków</summary>
        ///<remarks>Event wywołuje metodę refreshowanie która odświerza wszystkie widoki poszczególnych paneli z produktami</remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        /// 
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            refreshowanie();

        }

        ///<summary>Metoda odświerżjąca widoki</summary>
        ///<remarks>Pozwala to na aktualizowanie widzianych przez użytkownika elementów</remarks>
        public void refreshowanie()
        {

            CollectionViewSource.GetDefaultView(Item1.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(Item2.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(Item3.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(Item4.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(Item5.ItemsSource).Refresh();
           
        }

        ///<summary>Event odświeża widoki gdy w polu tekstowym odświeżania zostanie całkowicie usunięty łańcuch znaków</summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void tbFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(tbFilter.Text==string.Empty)
            {
                refreshowanie();
            }
        }


        ///<summary>Event w której dokonujemy jak zachowywać ma się program w dalszej częsci (wybieranie metody dowozu)</summary>      
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            CzyDowoz = false;

            mainGrid1.Visibility = Visibility.Visible;
            mainGrid3.Visibility = Visibility.Collapsed;
        }

        ///<summary>Event w której dokonujemy jak zachowywać ma się program w dalszej częsci (wybieranie metody dowozu)</summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            CzyDowoz = true;
            mainGrid1.Visibility = Visibility.Visible;
            mainGrid3.Visibility = Visibility.Collapsed;
        }

        ///<summary>Event kliknięcia buttona aktywacji  przejscia do kolejnej karty</summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            mainGrid3.Visibility = Visibility.Visible;
            mainGrid2.Visibility = Visibility.Collapsed;


        }

        ///<summary>Event naciśnięcia buttona jako przejscie do finalizacji zamówienia</summary>
        ///<remarks>Prowadzi on do karty w której to podajemy dane osobowe dołączane do zamówienia</remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            

            if (cenazamowienia.CenaCalkowita>0)
            {
                mainGrid1.Visibility = Visibility.Collapsed;
                odpowiedz.Visibility = Visibility.Collapsed;
                odpowiedz2.Visibility = Visibility.Collapsed;

                if (CzyDowoz==true)
                {
                    mainGrid4.Visibility = Visibility.Visible;
                    placeNiezdowozem.Visibility = Visibility.Visible;



                }
                if (CzyDowoz == false)
                {
                    mainGrid4.Visibility = Visibility.Visible;
                    placeNiezdowozem.Visibility = Visibility.Visible;

                    tbwymMie.Text = "Miejscowość:";
                    tbwymKod.Text = "Kod-pocztowy:";
                    tbwymUl.Text = "Ulica i numer:";




                }

            }

        }
        ///<summary>Metoda określająca metodę płatnosci</summary>
        ///<remarks>W zależnosci od tego czy który z 2 raddiobuttonów został wciśnięcy(płatnosc na miejscu/elektroniczna) podejmowane są dalsze działania</remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        /// <example>
        /// <code>
        /// if(rb1.IsChecked==true)
        /// {
        ///  //jezli rb1(płatnosc na miejscu) został wybrany to wszystkie produkty zamówione trafiają wspólnie do bazy danych jako 1 rekord (1 zamówienia)
        /// 
        /// }
        /// 
        /// 
        /// </code>
        /// </example>
        private void OkreslaniePlatnosci()
        {
            if(rb1.IsChecked==true)
            {
                nrZamowienia.Text = licznikZamowien.ToString();
                Utworzone.Text = DateTime.Today.ToString();
                lbstatusZam.Text = CzyDowoz == true ? "Dowóz" : "Na miejscu";
                Statusplatnosci.Text = "W trakcie";

                string opis = "";

                for (int i = 0; i < zamowioneprod.Count; i++)
                {
                    opis += (zamowioneprod[i].Nazwa + zamowioneprod[i].Ilosc + "szt." + " " + zamowioneprod[i].CenaAll + "$");
                    opis += "  ";

                }
                bazadanych.ZamowieniaDetail.Add(new ZamowieniaDetail { Nr_zamowienia = licznikZamowien, Imie = daneKonca.Imie, Nazwisko=daneKonca.Nazwisko, Miejscowość=daneKonca.Miejscowosc, Kod_pocztowy=daneKonca.Kod_pocztowy , Ulica_NrDomu= daneKonca.Ulica_NrDomu, Email= daneKonca.Email, Telefon= daneKonca.Telefon, Full_price= cenazamowienia.CenaCalkowita.ToString(), Opis_zamowienia=opis, Typ_platnosci="Przy_odbiorze", Status_platnosci="W trakcie", Charakter_zamowienia = CzyDowoz==true?"Dowóz":"Na miejscu", Data_zamowienia = DateTime.Today.ToString() });
                bazadanych.SaveChanges();
                mainGrid5.Visibility = Visibility.Visible;

            }
            else
            {
                mainGrid6.Visibility = Visibility.Visible;

            }

        }

        ///<summary>Event naciśnięcia butona potwiedzenia podanych danych osobowych</summary>
        ///<remarks>Działanie tego eventu polega w pierwszej kolejnosci na sprawdzeniu zmiennej CzyDowoz i na jej podsawie określenie czy wymagane
        ///dane podane przez urzytkownika są poprawne i czy może on przejść dalej.Dodawanie do zmiennej "daneKonca" , do własciwości której ten obiekt posiada odpowiednich wartosci danych urzytkownika podanych przez niego</remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>    
        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            
            if (CzyDowoz == true)
            {
                if (wypelnienie1.Text == String.Empty || wypelnienie2.Text == String.Empty || wypelnienie3.Text == String.Empty || wypelnienie4.Text == String.Empty || wypelnienie5.Text == String.Empty || (rb1.IsChecked == false && rb2.IsChecked == false))
                {


                    if (wypelnienie1.Text == String.Empty)
                    {
                        odpowiedz.Visibility = Visibility.Visible;
                        wypelnienie1.BorderBrush = Brushes.Red;
                    }
                    else
                    {
                        wypelnienie1.BorderBrush = Brushes.Black;

                    }

                    if (wypelnienie2.Text == String.Empty)
                    {
                        odpowiedz.Visibility = Visibility.Visible;
                        wypelnienie2.BorderBrush = Brushes.Red;
                    }
                    else
                    {
                        wypelnienie2.BorderBrush = Brushes.Black;

                    }

                    if (wypelnienie3.Text == String.Empty)
                    {
                        odpowiedz.Visibility = Visibility.Visible;
                        wypelnienie3.BorderBrush = Brushes.Red;
                    }
                    else
                    {
                        wypelnienie3.BorderBrush = Brushes.Black;

                    }

                    if (wypelnienie4.Text == String.Empty)
                    {
                        odpowiedz.Visibility = Visibility.Visible;
                        wypelnienie4.BorderBrush = Brushes.Red;
                    }
                    else
                    {
                        wypelnienie4.BorderBrush = Brushes.Black;

                    }

                    if (wypelnienie5.Text == String.Empty)
                    {
                        odpowiedz.Visibility = Visibility.Visible;
                        wypelnienie5.BorderBrush = Brushes.Red;
                    }
                    else
                    {
                        wypelnienie5.BorderBrush = Brushes.Black;

                    }
                    if (rb1.IsChecked == false && rb2.IsChecked == false)
                    {

                        odpowiedz2.Visibility = Visibility.Visible;
                    }
                    else if (rb1.IsChecked == true || rb2.IsChecked == true)
                    {
                        odpowiedz2.Visibility = Visibility.Collapsed;


                    }
                    if (wypelnienie1.Text != String.Empty && wypelnienie2.Text != String.Empty && wypelnienie3.Text != String.Empty && wypelnienie4.Text != String.Empty && wypelnienie5.Text != String.Empty)
                    {
                        odpowiedz.Visibility = Visibility.Collapsed;

                    }

                }


                else
                {

                    



                    daneKonca.Imie = wypelnienie1.Text;
                    daneKonca.Nazwisko = wypelnienie2.Text;
                    daneKonca.Miejscowosc = wypelnienie3.Text;
                    daneKonca.Kod_pocztowy = wypelnienie3.Text;
                    daneKonca.Ulica_NrDomu = wypelnienie4.Text;
                    daneKonca.Email = wypelnienie5.Text;
                    daneKonca.Telefon = wypelnienie6.Text;

                    //mainGrid5.Visibility = Visibility.Visible;
                    mainGrid4.Visibility = Visibility.Collapsed;
                    //DateTime.Now).ToString();
                    OkreslaniePlatnosci();
                    usuwaniebledow();






                }

            }
            else
            {
                if (wypelnienie1.Text == String.Empty || wypelnienie2.Text == String.Empty || (rb1.IsChecked == false && rb2.IsChecked == false))
                {


                    if (wypelnienie1.Text == String.Empty)
                    {
                        odpowiedz.Visibility = Visibility.Visible;
                        wypelnienie1.BorderBrush = Brushes.Red;
                    }
                    else
                    {
                        wypelnienie1.BorderBrush = Brushes.Black;

                    }

                    if (wypelnienie2.Text == String.Empty)
                    {
                        odpowiedz.Visibility = Visibility.Visible;
                        wypelnienie2.BorderBrush = Brushes.Red;
                    }
                    else
                    {
                        wypelnienie2.BorderBrush = Brushes.Black;

                    }

                    if (rb1.IsChecked == false && rb2.IsChecked == false)
                    {

                        odpowiedz2.Visibility = Visibility.Visible;
                    }
                    else if (rb1.IsChecked == true || rb2.IsChecked == true)
                    {
                        odpowiedz2.Visibility = Visibility.Collapsed;


                    }
                    if (wypelnienie1.Text != String.Empty && wypelnienie2.Text != String.Empty)
                    {
                        odpowiedz.Visibility = Visibility.Collapsed;

                    }

                }


                else
                {

                    daneKonca = new DaneKoncowe();



                    daneKonca.Imie = wypelnienie1.Text;
                    daneKonca.Nazwisko = wypelnienie2.Text;
                    daneKonca.Miejscowosc = wypelnienie3.Text;
                    daneKonca.Kod_pocztowy = wypelnienie3.Text;
                    daneKonca.Ulica_NrDomu = wypelnienie4.Text;
                    daneKonca.Email = wypelnienie5.Text;
                    daneKonca.Telefon = wypelnienie6.Text;

                    //mainGrid5.Visibility = Visibility.Visible;
                    mainGrid4.Visibility = Visibility.Collapsed;
                    //DateTime.Now).ToString();
                    OkreslaniePlatnosci();
                    usuwaniebledow();


                }
            }
            
            
            

        }

        /// <summary>
        /// Przycisk wyświetlania panelu ze sposobem płącenia visa
        /// </summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>    
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            sposobPlaceniaVisa.Visibility = Visibility.Visible;
        }

        ///<summary>Event na naciśnięcie przycisku potwierdzającego podane dane do płatnosci</summary>
        ///<remarks>Ciało tego eventu opiera się w pierwszej kolejnosci na wyborze która z metod płatnosci została wybrana.Następie sprawdzane
        ///są(np.w przypadku metody kartą Visa) po kolei dane podane prze użytkownika i porównywane z tymi z bazy danych(czy karta płatnicza o podanych danych znajduje się w bazie danych,
        ///Jesli tak operacja jest finalizowana).</remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>    
        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            if(sposobPlatnosci=="Visa")
            {
                KartaPlatniczaVisa karta = null;
                karta = bazadanych.KartaPlatniczaVisa.FirstOrDefault(n => n.Imie == ImieKarta.Text && n.Nazwisko == NazwiskoKarta.Text && n.Nr_karty == Nrkarta.Text && n.Kod == KodKarta.Text);
                if (karta != null)
                {
                    ImieKarta.BorderBrush = Brushes.Black;
                    NazwiskoKarta.BorderBrush = Brushes.Black;
                    Nrkarta.BorderBrush = Brushes.Black;
                    KodKarta.BorderBrush = Brushes.Black;

                    if (karta.Stan >= cenazamowienia.CenaCalkowita)
                    {
                        niepoprawnakarta.Visibility = Visibility.Collapsed;
                        karta.Stan -= cenazamowienia.CenaCalkowita;
                        bazadanych.SaveChanges();
                        OkreslaniePlatnosci();

                        nrZamowienia.Text = licznikZamowien.ToString();
                        Utworzone.Text = DateTime.Today.ToString();
                        lbstatusZam.Text = CzyDowoz == true ? "Dowóz" : "Na miejscu";
                        Statusplatnosci.Text = "Zapłacono";

                        string opis = "";

                        for (int i = 0; i < zamowioneprod.Count; i++)
                        {
                            opis += (zamowioneprod[i].Nazwa + zamowioneprod[i].Ilosc + "szt." + " " + zamowioneprod[i].CenaAll + "$");
                            opis += "  ";

                        }
                        bazadanych.ZamowieniaDetail.Add(new ZamowieniaDetail { Nr_zamowienia = licznikZamowien, Imie = daneKonca.Imie, Nazwisko = daneKonca.Nazwisko, Miejscowość = daneKonca.Miejscowosc, Kod_pocztowy = daneKonca.Kod_pocztowy, Ulica_NrDomu = daneKonca.Ulica_NrDomu, Email = daneKonca.Email, Telefon = daneKonca.Telefon, Full_price = cenazamowienia.CenaCalkowita.ToString(), Opis_zamowienia = opis, Typ_platnosci = "Płatność_internetowa", Status_platnosci = "Zapłacono", Charakter_zamowienia = CzyDowoz == true ? "Dowóz" : "Na miejscu", Data_zamowienia = DateTime.Today.ToString() });
                        bazadanych.SaveChanges();
                        mainGrid5.Visibility = Visibility.Visible;
                        mainGrid6.Visibility = Visibility.Collapsed;

                    }
                    else
                    {
                        niepoprawnakarta.Text = "Brak wystarczających środków na końcie";
                        niepoprawnakarta.Visibility = Visibility.Visible;

                    }
                }
                else
                {
                    if(ImieKarta.Text==string.Empty)
                    {
                        ImieKarta.BorderBrush = Brushes.Red;

                    }
                    else
                    {
                        ImieKarta.BorderBrush = Brushes.Black;

                    }
                    if (NazwiskoKarta.Text == string.Empty)
                    {
                        NazwiskoKarta.BorderBrush = Brushes.Red;

                    }
                    else
                    {
                        NazwiskoKarta.BorderBrush = Brushes.Black;

                    }
                    if (Nrkarta.Text == string.Empty)
                    {
                        Nrkarta.BorderBrush = Brushes.Red;

                    }
                    else
                    {
                        Nrkarta.BorderBrush = Brushes.Black;

                    }
                    if (KodKarta.Text == string.Empty)
                    {
                        KodKarta.BorderBrush = Brushes.Red;

                    }
                    else
                    {
                        KodKarta.BorderBrush = Brushes.Black;

                    }
                    niepoprawnakarta.Text = "Karta błędna lub nieprawidłowe dane";
                    niepoprawnakarta.Visibility = Visibility.Visible;
                }

            }
            else if(sposobPlatnosci=="Maestro")
            {

            }
            else if (sposobPlatnosci == "MasterCard")
            {

            }
            else if (sposobPlatnosci == "PayPal")
            {

            }
            else
            {
                bladmetodyPlatnosci.Visibility = Visibility.Visible;

            }    



        }


        ///<summary>Event cofnięcia pomiędzy kartami</summary>
        ///<remarks>Naciśnięcie buttona polega na ustawieniu własciwosci visibility jednej karty na collapsed i drugiej na visible</remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            mainGrid4.Visibility = Visibility.Visible;
            mainGrid6.Visibility = Visibility.Collapsed;
        }


        ///<summary>Zamknięcie aplikacji</summary>
        ///<remarks>Event wywołująca w swoim ciele metodę mods dla obecnego obiektu co spowoduje zamknięcie aplikacji</remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        ///<summary>Event cofnięcia pomiędzy kartami</summary>
        ///<remarks>Naciśnięcie buttona polega na ustawieniu własciwosci visibility jednej karty na collapsed i drugiej na visible</remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            mainGrid3.Visibility = Visibility.Visible;
            mainGrid1.Visibility = Visibility.Collapsed;
        }

        ///<summary>Event cofnięcia pomiędzy kartami i dodatkowo resetowanie wartosci posczególnych zmiennych i obiektów</summary>
        ///<remarks>Naciśnięcie buttona polega na ustawieniu własciwosci visibility jednej karty na collapsed i drugiej na visible.Resetowanie polega na przywróceniu wartosci zmiennych do tych z początku programu aby możliwe było ponowne zamawianie produktów</remarks>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            resetowanie();
            przyciskkolor(0);
            wyswietlanie(0);
            Licznikproduktu = 1;
            mainGrid1.Visibility = Visibility.Visible;
            mainGrid5.Visibility = Visibility.Collapsed;




        }
       
       
        ///<summary>
        ///Event na naciśnięcie przycisku wyswietlnia sposobu płątnosci kartą Visa
        ///</summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            bladmetodyPlatnosci.Visibility = Visibility.Collapsed;
            sposobPlatnosci = "Visa";
            sposobPlaceniaVisa.Visibility = Visibility.Visible;
        }

        ///<summary>
        ///Event cofnięcia pomiędzy kartami
        ///</summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_21(object sender, RoutedEventArgs e)
        {
           
            mainGrid4.Visibility = Visibility.Collapsed;
            mainGrid1.Visibility = Visibility.Visible;
            usuwaniebledow();
        }

        /// <summary>
        /// Jest to metoda która odpowiada za ukrywanie wyświetlanych błędów źle wprowadzonych danych
        /// </summary>
        private void usuwaniebledow()
        {
            odpowiedz.Visibility = Visibility.Collapsed;
            odpowiedz2.Visibility = Visibility.Collapsed;
            wypelnienie1.BorderBrush = Brushes.Black;
            wypelnienie2.BorderBrush = Brushes.Black;
            wypelnienie3.BorderBrush = Brushes.Black;
            wypelnienie4.BorderBrush = Brushes.Black;
            wypelnienie5.BorderBrush = Brushes.Black;
            wypelnienie6.BorderBrush = Brushes.Black;
            wypelnienie7.BorderBrush = Brushes.Black;

        }

        ///<summary>
        ///Przesłonięcie gridu 
        ///</summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            spDodwanieProduktu.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_23(object sender, RoutedEventArgs e)
        {

        
           

        }

        ///<summary>
        ///Event kontrolki określającej wybór opisu dla kontretnie wybranego produktu
        ///</summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>

        private void moreAboutProducts_Click(object sender, RoutedEventArgs e)
        {
            if(Licznikproduktu==1)
            {
                OpisyProduktow.DataContext = (Item1.SelectedItem as Oferty);
               

            }
            if (Licznikproduktu == 2)
            {
                OpisyProduktow.DataContext = (Item2.SelectedItem as Oferty);
              

            }
            if (Licznikproduktu == 3)
            {
                OpisyProduktow.DataContext = (Item3.SelectedItem as Oferty);
                

            }
            if (Licznikproduktu == 4)
            {
                OpisyProduktow.DataContext = (Item4.SelectedItem as Oferty);
               

            }
            if (Licznikproduktu == 5)
            {
                OpisyProduktow.DataContext = (Item5.SelectedItem as Oferty);
              

            }
            OpisyProduktow.Visibility = Visibility.Visible;
        }




        ///<summary>
        ///Przesłonięcie gridu 
        ///</summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>

        private void Button_Click_24(object sender, RoutedEventArgs e)
        {
            OpisyProduktow.Visibility = Visibility.Collapsed;

        }



        ///<summary>
        ///Zamknięcie aplikacji 
        ///</summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_25(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        ///<summary>
        ///Event pozwalający na przesuwanie głównego okna 
        ///</summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();

        }


        ///<summary>
        ///Event przycisku powodującego zwiększanie wartosci zmiennej odpowiadającej za ilość zakupionych produktów 
        ///</summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_27(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(wpisywanieIloscitb.Text) + 1;
            wpisywanieIloscitb.Text = a.ToString();
        }

      


        /// <summary>
        /// Event przycisku powodującego zmniejszanie wartosci zmiennej odpowiadającej za ilość zakupionych produktów
        /// </summary>
        /// <param name="sender">określa obiekt który wywołał dany event</param
        /// <param name="e">Zawiera informacje o stanie i dane zdarzenia powiązane ze zdarzeniem kierowanym.</param>>
        private void Button_Click_28(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(wpisywanieIloscitb.Text) -1;
            wpisywanieIloscitb.Text = a.ToString();

        }
    }
}
