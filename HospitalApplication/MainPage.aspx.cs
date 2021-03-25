using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DataProvider;

namespace HospitalApplication
{
    class VisitInfo
    {
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public DateTime Date { get; set; }
    }

    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ReadData())
                {
                    DoctorsGridView.DataSource = Doctors.Values;
                    PatientsGridView.DataSource = Patients.Values;
                    var visitInfos = new List<VisitInfo>();
                    var years = new SortedSet<int>();
                    foreach (var visit in Visits)
                    {
                        visitInfos.Add(new VisitInfo
                        {
                            Doctor = Doctors[visit.DoctorId].Name,
                            Patient = Patients[visit.PatientId].Name,
                            Date = visit.VisitDate
                        });
                        years.Add(visit.VisitDate.Year);
                    }
                    VisitsGridView.DataSource = visitInfos;
                    DoctorsGridView.DataBind();
                    PatientsGridView.DataBind();
                    VisitsGridView.DataBind();
                    YearDropDownList.Items.Clear();
                    foreach (var year in years)
                    {
                        YearDropDownList.Items.Add(year.ToString());
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["year"] = YearDropDownList.SelectedValue;
            Response.Redirect("ResultPage1.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResultPage2.aspx");
        }
    }
}