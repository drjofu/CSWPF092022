using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisposableBeispiel
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      //using (Pen stift = new Pen(Color.FromArgb(255, 200, 10), 5))
      //using(Pen stift2=new Pen(Color.Green))
      //{ 
      //  e.Graphics.DrawEllipse(stift, 50, 50, 100, 100);
      //}
      //stift.Dispose();

      using Pen stift = new Pen(Color.FromArgb(255, 200, 10), 5);
      e.Graphics.DrawEllipse(stift, 50, 50, 100, 100);
      e.Graphics.DrawEllipse(stift, 150, 150, 100, 100);
    }
  }
}
