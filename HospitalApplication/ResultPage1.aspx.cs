using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DataProvider;

namespace HospitalApplication
{
    public partial class ResultPage1 : System.Web.UI.Page
    {
        class ResultItem
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Doctors?.Count > 0 && Patients?.Count > 0 && Visits?.Count > 0)
            {
                if (!IsPostBack && Session.Keys.OfType<string>().Contains("year"))
                {
                    int year = Convert.ToInt32(Session["year"]);
                    var dict = new Dictionary<int, DateTime>();
                    foreach (var visit in Visits)
                    {
                        if (visit.VisitDate.Year == year)
                        {
                            int id = visit.DoctorId;
                            if (!dict.ContainsKey(id) || dict[id] > Patients[visit.PatientId].BirthDate)
                            {
                                dict[id] = Patients[visit.PatientId].BirthDate;
                            }
                        }
                    }
                    if (dict.Count > 0)
                    {
                        var resultList = new List<ResultItem>();
                        foreach (var item in dict)
                        {
                            resultList.Add(new ResultItem
                            {
                                Name = Doctors[item.Key].Name,
                                Age = DateTime.Today.Year - item.Value.Year
                            });
                        }
                        ResultGridView.DataSource = resultList;
                        ResultGridView.DataBind();
                    }
                    else
                        Response.Write(@"<script>alert('No solution')</script>");
                }
                else
                    Response.Write(@"<script>alert('Undefined year')</script>");
            }
            else
                Response.Write("<script>alert('Data are missing')</script>");

        }
    }
}