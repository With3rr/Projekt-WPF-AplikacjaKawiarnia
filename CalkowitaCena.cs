using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSzkolenieTechniczne
{
    /// <summary> Klasa która określa całkowitą cenę zamówienia.  </summary>
    ///<remarks> Klasa ta ma za zadanie ogreślić obiekt który będzie zsumowaną ceną wszystkich zamówionych produktów, poziada odpowiednie własciwościo oraz oraz metody oraz implementuje interfejt INotifyPropertyChanged</remarks>
    class CalkowitaCena :INotifyPropertyChanged
    {
        /// <summary> Bezargumentowy konstruktor klasy który ustawia wartość właściwości CenaCalkowita na 0.  </summary>
        public CalkowitaCena()
        {
            CenaCalkowita = 0;
        }
        /// <value>właściwość cenaMax  jest właściwością prywatną oraz pozwala na pobieranie oraz zapisywanie wartości typu double do niej jednak odbywa się to przez inną właściwość gdyż ta służy tylko jako pewnego rodzaju kontener nie dostępny z zewnątrz</value>
        private double cenaMax { get; set; }
        /// <value>właściwość ta jest powiązana bezpośrednio z właściwością cenaMax gdyż to ta właściwość pełni rolę akcesora  do tamtej prywatnej,i ma możliwość pobierania i zapisywania wartości  typu double rprezyntującą Całkowitą cenę</value>
        public double CenaCalkowita
        {
            get
            {
                return cenaMax;
            }
            set
            {

                cenaMax = value;
                ///jezeli do zmiennej delegatowej nie została jeszcze przypisana żadna funkcja (+=) to nie możemy wywołać określonych funkcji powiązanych z tą zmienną,w przeciwnym przypadku wywołujemy PropertyChanded z parametrami this,oraz z nowym obiektem PropertyChangedEventArgs i podajemy  w nazwiasach nazwę powiązanej własciwości
                if(PropertyChanged!=null)
                {
                    ///Wywołanie metody z określonymi parametrami które przedstawione zostały w opisie metody PropertyChandeg
                    PropertyChanged(this, new PropertyChangedEventArgs("CenaCalkowita"));

                }
                

            }
        }


        ///<summary>Metoda ustalająca wartość własciwości</summary>
        ///<remarks> Metoda która nic nie zwraca i nie przyjmuje argumentów ,jej zadaniem będzie przypisanie wartości 0 do własciwości CenaCalkowita (zerowania ceny)</remarks>
        public void Zeruj()
        {
            CenaCalkowita = 0;
        }

        /// <summary>Reprezentuje metodę, która będzie obsługiwać System.ComponentModel.INotifyPropertyChanged.PropertyChanged </summary>
        /// <param name="sender">Źródło wydarzenia..</param>
        /// <param name="e">System.ComponentModel.PropertyChangedEventArgs, który zawiera dane zdarzenia..</param>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
