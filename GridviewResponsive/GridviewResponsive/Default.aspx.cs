using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GridviewResponsive
{
    public partial class Default : System.Web.UI.Page
    {
        NorthwindDataContext dc = new NorthwindDataContext();
        private static List <smi_order> _orders;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (_orders==null ||_orders.Count == 0)
            {
                var qry = from s in dc.smi_orders
                          select s;
                _orders = qry.Where(p => p.Levertdato == null && (p.deleted==null)).ToList();

                GridView1.DataSource = _orders;
                GridView1.DataBind();

            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (_orders.Count >0)
            _orders.RemoveAt(0);
            else
            {
                var qry = from s in dc.smi_orders
                          select s;
                _orders = qry.Where(p => p.Levertdato == null).ToList();
            }

            GridView1.DataSource = _orders;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var i=e.Row.Cells.Count;
                DateTime d ;
                if (DateTime.TryParse(e.Row.Cells[i - 1].Text, out d))
                if (d.CompareTo(DateTime.Today.AddDays(-1))<0)
                {
                    // change the color
                    e.Row.ForeColor = System.Drawing.Color.Red;
                } else
                    {
                        switch (e.Row.Cells[2].Text)
                        {
                          case "Bol": e.Row.ForeColor = System.Drawing.Color.Pink;
                                e.Row.BackColor = System.Drawing.Color.Black;
                                break;
                           case "Jon": e.Row.ForeColor = System.Drawing.Color.Yellow;
                                e.Row.BackColor = System.Drawing.Color.Black;
                                break;
                            case "Mar": e.Row.ForeColor = System.Drawing.Color.Red;
                                e.Row.BackColor = System.Drawing.Color.Black;
                                break;
                           case "Nan": e.Row.ForeColor = System.Drawing.Color.Green;
                                e.Row.BackColor = System.Drawing.Color.Black;
                                break;
                           case "Ran": e.Row.ForeColor = System.Drawing.Color.LightBlue;
                                e.Row.BackColor = System.Drawing.Color.Black;
                                break;
                           case "Rod": e.Row.ForeColor = System.Drawing.Color.Black;
                                       e.Row.BackColor = System.Drawing.Color.Pink;
                                break;
                            case "Sta": e.Row.ForeColor = System.Drawing.Color.Navy;
                                e.Row.BackColor = System.Drawing.Color.GreenYellow;
                                break;
                            case "Haster": e.Row.ForeColor = System.Drawing.Color.MediumOrchid; break;
                        }

                    }
            }
        }
    }

}