using Sistema_Biblioteca.Clases;
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

namespace Sistema_Biblioteca.UC_Informe
{
    /// <summary>
    /// Lógica de interacción para UC_Informe_Bajas.xaml
    /// </summary>
    public partial class UC_Informe_Bajas : UserControl
    {
        public UC_Informe_Bajas()
        {
            InitializeComponent();
            dataGrid_Bajas.DataContext = Clase_Baja.lista_Bajas();
        }
    }
}
