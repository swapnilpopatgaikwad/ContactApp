using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    public class Customsearchcontact
    {
          public string? company_name { get; set; }
          public string? keyword { get; set; }
          public List<string>? company_industry { get; set; }
          public List<string>? company_size { get; set; }
          public List<string>? revenue_range { get; set; }
          public List<string>? seniority_level { get; set; }
          public List<string>? lead_division { get; set; }
          public List<string>? email_score { get; set; }
          public string? lead_titles { get; set; }
          public string? lead_location { get; set; }
          public string? name { get; set; }
          public string? email { get; set; }
          public string? company_naics_code { get; set; }
          public string? company_sic_code { get; set; }
          public string? company_profile_image_url { get; set; }
          public string? linkedin_url { get; set; }
          public int? PerExportLimit { get; set; }
          



    }
}
