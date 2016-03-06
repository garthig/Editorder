using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace GridviewResponsive
{
    public partial class Default : System.Web.UI.Page
    {
        NorthwindDataContext dc = new NorthwindDataContext();
        private static List <smi_order> _orders;
        private GridViewSortEventArgs _lastSort = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Refreshdata();

            }

        }

        private void Refreshdata()
        {
            var qry = from s in dc.smi_orders
                      select s;
            _orders = qry.Where(p=>p.deleted == null).ToList();
            GridView1.DataSource = _orders;
            GridView1.DataBind();
        }
        private void Refresh()
        {
            if (_orders == null)
                Refreshdata();
            else
            {
                GridView1.DataSource = _orders;
                GridView1.DataBind();
            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Refresh();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
        
            string execsql = "exec [dbo].[Update_smi_order_ny] @Varenr =" + ((Label)GridView1.Rows[e.RowIndex].Cells[1].Controls[1]).Text+
                             ",@Ansvarlig ='" +((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[1]).Text + "'" +
                           " ,@Kunde ='" + ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[1]).Text + "'" +
                           ", @Varenavn  ='" + ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[1]).Text + "'" +
                           ", @Bestillinsdato  ='" + ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[1]).Text + "'" +
                           ", @ForventetLevering  ='" + ((TextBox)GridView1.Rows[e.RowIndex].Cells[6].Controls[1]).Text + "'" +
                           ", @Levertdato ='" + ((TextBox)GridView1.Rows[e.RowIndex].Cells[7].Controls[1]).Text + "'";
            dc.ExecuteCommand(execsql);
            GridView1.EditIndex = -1;
           Refreshdata();



        }

        protected void Nybtn_Click(object sender, EventArgs e)
        {
            string execsql = "exec [dbo].[Add_smi_order] @Ansvarlig ='" +
                             ((TextBox) GridView1.FooterRow.Cells[3].Controls[1]).Text + "'" +
                             " ,@Kunde ='" + ((TextBox) GridView1.FooterRow.Cells[4].Controls[1]).Text + "'" +
                             ", @Varenavn  ='" + ((TextBox) GridView1.FooterRow.Cells[2].Controls[1]).Text + "'" +
                             ", @Bestillinsdato  ='" + ((TextBox) GridView1.FooterRow.Cells[5].Controls[1]).Text + "'" +
                             ", @ForventetLevering  ='" + ((TextBox) GridView1.FooterRow.Cells[6].Controls[1]).Text +"'" +
                             ", @Levertdato ='" + ((TextBox) GridView1.FooterRow.Cells[7].Controls[1]).Text + "'";
           dc.ExecuteCommand(execsql);

            Refreshdata();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Refresh();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string execsql = "Update [dbo].[smi_order] set deleted=1 where Varenr =" +
                             ((Label) GridView1.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
                
           dc.ExecuteCommand(execsql);
            Refreshdata();
        }
        
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            switch (e.SortExpression)
            {
                case "Bestillinsdato": GridView1.DataSource = _orders.OrderBy(p => p.Bestillinsdato).ToList();
                   // if(_lastSort!=null && _lastSort.SortExpression==e.SortExpression && _lastSort.SortExpression)
                    break;
                case "Ansvarlig":
                    GridView1.DataSource = _orders.OrderBy(p => p.Ansvarlig).ToList();
                    break;
                case "Varenr":
                    GridView1.DataSource = _orders.OrderBy(p => p.Varenr).ToList();
                    break;
                case "ForventetLevering":
                    GridView1.DataSource = _orders.OrderBy(p => p.ForventetLevering).ToList();
                    break;
                case "Varenavn":
                    GridView1.DataSource = _orders.OrderBy(p => p.Varenavn).ToList();
                    break;
                case "Levertdato":
                    GridView1.DataSource = _orders.OrderBy(p => p.Levertdato).ToList();
                    break;
                case "Kunde":
                    GridView1.DataSource = _orders.OrderBy(p => p.Kunde).ToList();
                    break;
            }
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string txt = "";
            if (e.Row.Cells[3].Controls.Count > 1)
            {
                if(e.Row.Cells[3].Controls[1].GetType().ToString().Contains("TextBox"))
                       txt= ((TextBox)(e.Row.Cells[3].Controls[1])).Text;
                else if (e.Row.Cells[3].Controls[1].GetType().ToString().Contains("Label"))
                    txt = ((Label)(e.Row.Cells[3].Controls[1])).Text;

            }
              switch (txt.ToUpper())
            {
                case "BOL":
                    e.Row.ForeColor = System.Drawing.Color.Pink;
                    e.Row.BackColor = System.Drawing.Color.Black;
                    break;
                case "JON":
                    e.Row.ForeColor = System.Drawing.Color.Yellow;
                    e.Row.BackColor = System.Drawing.Color.Black;
                    break;
                case "MAR":
                    e.Row.ForeColor = System.Drawing.Color.Red;
                    e.Row.BackColor = System.Drawing.Color.Black;
                    break;
                case "NAN":
                    e.Row.ForeColor = System.Drawing.Color.Green;
                    e.Row.BackColor = System.Drawing.Color.Black;
                    break;
                case "RAN":
                    e.Row.ForeColor = System.Drawing.Color.LightBlue;
                    e.Row.BackColor = System.Drawing.Color.Black;
                    break;
                case "ROD":
                    e.Row.ForeColor = System.Drawing.Color.Black;
                    e.Row.BackColor = System.Drawing.Color.Pink;
                    break;
                case "STA":
                    e.Row.ForeColor = System.Drawing.Color.Navy;
                    e.Row.BackColor = System.Drawing.Color.GreenYellow;
                    break;
                case "HASTER": e.Row.ForeColor = System.Drawing.Color.MediumOrchid; break;
            }
        }
    }

}