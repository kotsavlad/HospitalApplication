using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DataProvider;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Doctors?.Count > 0 &&  Patients?.Count > 0 && Visits?.Count > 0)
            {
                if (!IsPostBack)
                {
                    var specialities = new HashSet<string>();
                    foreach (var doctor in DataProvider.Doctors)
                    {
                        specialities.Add(doctor.Value.Speciality);
                    }
                    // Additional dict. Key is a patient id, Value is a set of specialities which corresponds to this patient
                    var dict = new Dictionary<int, HashSet<string>>();
                    foreach (var visit in DataProvider.Visits)
                    {
                        var id = visit.PatientId;
                        if (!dict.ContainsKey(id))
                            dict[id] = new HashSet<string>();
                        dict[id].Add(DataProvider.Doctors[visit.DoctorId].Speciality);
                    }
                    var specCount = specialities.Count;
                    ResultListBox.Items.Clear();
                    if (dict.Count > 0)
                    {
                        bool found = false;
                        foreach (var item in dict)
                        {
                            if (item.Value.Count == specCount)
                            {
                                found = true;
                                ResultListBox.Items.Add(DataProvider.Patients[item.Key].Name);
                            }
                            if (!found)
                                Response.Write("<script>alert('Needed patients are missing')</script>");
                        }
                    }
                    else
                        Response.Write("<script>alert('Needed patients are missing')</script>");
                }
            }
            else
                Response.Write("<script>alert('Data are missing')</script>");
        }
    }
}