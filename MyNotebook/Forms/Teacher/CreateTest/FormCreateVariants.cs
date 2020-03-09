using MyNotebook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNotebook.Forms.Teacher.CreateTest
{
    public partial class FormCreateVariants : Form
    {
        Test Test;
        public FormCreateVariants(Test test)
        {
            InitializeComponent();
            StyleApply.ForForm(this);
            Test = test;
        }
    }
}
