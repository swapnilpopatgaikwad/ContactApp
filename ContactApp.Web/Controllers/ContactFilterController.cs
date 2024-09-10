using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using ContactApp.DataAccess.Data;
using ContactApp.DataAccess.IRepository;
using ContactApp.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using NuGet.Packaging.Signing;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Collections.Specialized.BitVector32;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContactApp.Web.Controllers
{
    [Authorize]
    public class ContactFilterController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly INotyfService _notyfService;
        


        public ContactFilterController(ApplicationDbContext db, INotyfService notyfService)
        {
            _db = db;
            _notyfService = notyfService;
        }
        public async Task<IActionResult> Index()
        {
            
            string email = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email, StringComparison.OrdinalIgnoreCase)).Value;
            var result = await _db.tblUsers.Where(x => x.Email == email).FirstOrDefaultAsync();
            
            if (result == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                List<string> companysize = new List<string>()
            {
                "0 - 9",
                "20 - 49",
                "50 - 99",
                "100 - 249",
                "250 - 499",
                "500 - 999",
                "1,000 - 4,999",
                "5,000 - 9,999",
                "10,000+"

            };
                List<string> revenuesize = new List<string>()
            {

                "$1 - $1M",
                "$1M - $5M",
                "$5M - $10M",
                "$10M - $25M",
                "$25M - $50M",
                "$50M - $100M",
                "$100M - $250M",
                "$250M - $500M",
                "$500M - $1B",
                "$1B - $2.5B",
                "$2.5B - $5B",
                "$5B+"


            };
                List<string> leveldata = new List<string>()
            {
                "C-Level",
                "VP-Level",
                "Director",
                "Manager",
                "Non-Manager"
            };


                var industrylistdata = new RawCompanyIndustry
                {
                    heading1 = new List<string>
                    {
                            "Farming",
                            "Ranching",
                            "Fishery",
                            "Dairy"


                },
                    heading2 = new List<string>
                    {

                                "Accounting",
                                "Management Consulting",
                                "Business Supplies and Equipment",
                                "Professional Training & Coaching",
                                "Outsourcing/Offshoring",
                                "Staffing and Recruiting",
                                "Graphic Design",
                                "Market Research",
                                "Events Services",
                                "Information Technology and Services",
                                "Public Relations and Communications",
                                "Translation and Localization",
                                "Program Development",
                                "Security and Investigations",
                                "Design",
                                "Market Research"
                    },
                    heading3 = new List<string>
                        {
                                    "Civil Engineering",
                                    "Building Materials",
                                    "Architecture & Planning",
                                    "Machinery",
                                    "Textiles",
                                    "Construction"


                        },
                    heading4 = new List<string>
                    {

                            "Consumer Goods",
                            "Consumer Electronics",
                            "Consumer Services",
                            "Food & Beverages",
                            "Arts and Crafts"


                },
                    heading5 = new List<string>
               {
                        "Higher Education",
                        "Primary/Secondary Education",
                        "Education Management",
                        "E-Learning"

                 },
                    heading6 = new List<string>
                 {
                        "Oil & Energy",
                        "Utilities",
                        "Renewables & Environment",
                        "Environmental Services"

                 },
                    heading7 = new List<string>
                 {
                        "Banking",
                        "Financial Services",
                        "Investment Banking",
                        "Venture Capital & Private Equity",
                        "Capital Markets",
                        "Investment Management"


                    },
                    heading8 = new List<string>
                   {

                   "Government Administration",
                    "Public Policy",
                    "Legislative Office",
                    "Military",
                    "Political Organization",
                    "Law Enforcement",
                    "Public Safety"

                   },
                    heading9 = new List<string>
                   {

                    "Hospital & Health Care",
                    "Medical Practice",
                    "Mental Health Care",
                    "Biotechnology",
                    "Medical Devices",
                    "Alternative Medicine"


                    },
                    heading10 = new List<string>
                      {
                        "Restaurants",
                        "Hotels",
                        "Leisure Travel & Tourism",
                        "Hospitality"

                    },

                    heading11 = new List<string>
                      {

                        "Medical Practice",
                        "Healthcare Services" 

                    },


                    heading12 = new List<string>
                      {


                       "Insurance",
                        "Pharmaceuticals"


                    },


                    heading13 = new List<string>
                      {

                        "Law Practice",
                        "Legal Services",
                        "Alternative Dispute Resolution",
                        "Law Enforcement"

                    },


                    heading14 = new List<string>
                      {

                       "Machinery",
                        "Electrical/Electronic Manufacturing",
                        "Chemical Manufacturing",
                        "Industrial Automation",
                        "Glass Ceramics & Concrete",
                        "Plastics",
                        "Tobacco",
                        "Nanotechnology",
                        "Textiles",
                        "Printing",
                        "Packaging and Containers"

                    },

                    heading15 = new List<string>
                      {

                        "Internet",
                        "Broadcast Media",
                        "Media Production",
                        "Online Media",
                        "Fine Art",
                        "Music",
                        "Photography",
                        "Animation",
                        "Motion Pictures and Film"



                    },

                    heading16 = new List<string>
                      {
                        "Mining & Metals",
                        "Minerals",
                        "Oil & Energy"


                    },

                    heading17 = new List<string>
                      {


                        "Nonprofit Organization Management",
                        "Civic & Social Organization",
                        "Think Tanks",
                        "Religious Institutions",
                        "Libraries",
                        "International Affairs",
                        "Philanthropy",
                        "Fund-Raising",
                        "Political Organization",
                        "Import and Export"


                    },

                    heading18 = new List<string>
                      {


                        "Commercial Real Estate",
                        "Real Estate",
                        "Property Management",
                        "Investment Management"

                    },

                      heading19= new List<string>
                      {


                        "Supermarkets",
                        "Apparel & Fashion",
                        "Consumer Electronics",
                        "Retail",
                        "Luxury Goods & Jewelry",
                        "Wine and Spirits",
                        "Furniture"

                    },

                    heading20 = new List<string>
                      {


                        "Computer Software",
                        "Software Development",
                        "Semiconductors",
                        "Computer Games",
                        "Computer Hardware",
                        "Computer & Network Security"

                    },


                    heading21 = new List<string>
                      {


                        "Telecommunications",
                        "Wireless",
                        "Computer Networking",
                        "Internet Services"

                    },

                    heading22 = new List<string>
                      {

                        "Transportation/Trucking/Railroad",
                        "Logistics and Supply Chain",
                        "Maritime",
                        "Package/Freight Delivery",
                        "Aviation & Aerospace",
                        "Railroad Manufacture",
                        "Shipbuilding"

                    },

                    heading23 = new List<string>
                      {

                        "Civil Engineering Construction",
                        "Design Business Services",
                        "Biotechnology Healthcare Services",
                        "Consumer Electronics Retail",
                        "Fine Art Media & Internet",
                        "Luxury Goods & Jewelry Retail",
                        "Market Research Business Services",
                        "Packaging and Containers Manufacturing",
                        "Pharmaceuticals Healthcare Services",
                        "Printing Manufacturing",
                        "Renewables & Environment Energy, Utilities & Waste",
                        "Security and Investigations Business Services",
                        "Textiles Manufacturing"

                    },
                    heading24 = new List<string>
                    {
                     "Conglomerates"

                    }






                    };

                var joblistdata = new RawIndustry
                {
                    headingjob1 = new List<string>
                    {
                      "C-Suite"

                },
                
                    headingjob2 = new List<string>
                {
                    "Accounting",
                    "Finance",
                    "Audit",
                    "Compensation And Benefits",
                    "Bids And Procurement",
                    "Corporate Development",
                    "Regulatory And Compliance",
                    "Risk Management",
                    "Process Improvement",
                    "Financial Planning And Analysis"


                },
               
                    headingjob3 = new List<string>
                {
                    "Regulatory And Compliance",
                    "Contracts And Agreements",
                    "Risk Management",
                    "Corporate Development",
                    "Intellectual Property",
                    "Litigation",
                    "Environmental Law",
                    "Mergers And Acquisitions",
                    "Compliance Management",
                    "Legal Support Services"

                },

                    headingjob4 = new List<string>
                {

                    "IT Security",
                    "Risk Management",
                    "Regulatory And Compliance",
                    "Data Management",
                    "Network Security",
                    "Server And Storage Security",
                    "Compliance Management",
                    "Incident Response",
                    "Identity And Access Management",
                    "Vulnerability Assessment"


                        },



                    headingjob5 = new List<string>
                {

                    "Operations Management",
                    "Logistics And Distribution",
                    "Inventory And Merchandise",
                    "Quality Control And Maintenance",
                    "Process Improvement",
                    "Supply Chain Management",
                    "Project Management/Business Analysis",
                    "Vendor Management",
                    "Procurement",
                    "Facility Management"



                        },


                    headingjob6 = new List<string>
                {

                    "Product Management",
                    "Project Management/Business Analysis",
                    "Design And Experience",
                    "Research",
                    "Quality Control And Maintenance",
                    "Innovation",
                    "Process Improvement",
                    "Testing And QA",
                    "DevOps",
                    "Software Engineering"




                        },

                    headingjob7 = new List<string>
                {

                    "Data Science/Data Engineering",
                    "BI And Analytics",
                    "Machine Learning/Deep Learning",
                    "Data Management",
                    "Research",
                    "Process Improvement",
                    "Data Visualization",
                    "Business Intelligence",
                    "Predictive Analytics",
                    "Data Strategy"





                        },


                    headingjob8 = new List<string>
                {

                    "Information Technology/Systems",
                    "Networking",
                    "Server And Storage",
                    "DevOps",
                    "IT Security",
                    "Project Management/Business Analysis",
                    "Cloud Computing",
                    "Technical Support",
                    "Infrastructure Management",
                    "Process Improvement"


                        },

                    headingjob9 = new List<string>
                    {

                    "Customer Support",
                    "Customer Success",
                    "Inside Sales/Field Sales",
                    "Sales Development",
                    "Lead Generation",
                    "Account Management",
                    "Pre-Sales",
                    "Sales Operations",
                    "Customer Retention",
                    "Technical Support"


                        },


                    headingjob10 = new List<string>
                    {

                    "Talent Acquisition",
                    "Compensation And Benefits",
                    "Learning And Development",
                    "Employee Relations",
                    "HR Analytics",
                    "Diversity & Inclusion",
                    "Workforce Planning",
                    "Performance Management",
                    "Succession Planning",
                    "Compliance Management"


                   },

                    headingjob11 = new List<string>
                {
                    "Content Marketing",
                    "Brand Management",
                    "Media And PR",
                    "SEO And SEM",
                    "Email And Social Media Marketing",
                    "Advertising And Promotions",
                    "Affiliate Marketing",
                    "Marketing And Growth",
                    "Lead Generation",
                    "Partnerships",

                },
                

                   

                };

                List<string> accuracyscore = new List<string>()
            {
                "70",
                "75",
                "85",
                "99"
                
            };


                ViewBag.companysizelist = companysize;
                ViewBag.revenuelist = revenuesize;
                ViewBag.Joblist = joblistdata;
                ViewBag.levellist = leveldata;
                ViewBag.industrylist = industrylistdata;
                ViewBag.accuracyscorelist = accuracyscore;
                ViewBag.totalcount = 0;
               

                try
                {

                    string email_id = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email, StringComparison.OrdinalIgnoreCase)).Value;
                    var uderdata2 = await _db.tblUsers.Where(x => x.Email == email_id).FirstOrDefaultAsync();
                    int searchlimit2 = Convert.ToInt32(uderdata2.searchlimit);
                    int AllSearchLimit3 = _db.tblSearchlimit.Where(option => option.SearchBy == uderdata2.Id && option.SearchLimitDate.Date == DateTime.Today).Select(option => option.SearchLimitCount).Sum();

                    if (AllSearchLimit3 >= searchlimit2 + 1)
                    {

                        _notyfService.Error("You’ve reached your daily export. Please Upgrade your plan.");

                    }


                

                }
                catch (Exception e) { }


                return View(result);
            }


        }

       
        [HttpPost]
        public async Task<string> getTotalContacs([FromBody] Customsearchcontact? searchdata)
        {
            var query = _db.tblContacts.AsQueryable();

            if (searchdata != null)
            {

                if (searchdata.company_industry != null && searchdata.company_industry?.Count > 0)
                    query = query.Where(x => searchdata.company_industry.Contains(x.company_industry));

                if (searchdata.lead_division != null && searchdata.lead_division?.Count > 0)
                    query = query.Where(x => searchdata.lead_division.Contains(x.lead_division));

                if (searchdata.seniority_level != null && searchdata.seniority_level?.Count > 0)
                    query = query.Where(x => searchdata.seniority_level.Contains(x.seniority_level));

                if (searchdata.email_score != null && searchdata.email_score?.Count > 0)
                    query = query.Where(x => searchdata.email_score.Contains(x.email_score));

                if (!string.IsNullOrWhiteSpace(searchdata.keyword))
                    query = query.Where(x => x.company_sector == searchdata.keyword);

                if (!string.IsNullOrWhiteSpace(searchdata.lead_location))
                    query = query.Where(x => x.lead_location == searchdata.lead_location);

                if (!string.IsNullOrWhiteSpace(searchdata.name))
                    query = query.Where(x => x.name == searchdata.name);
                

                if (!string.IsNullOrWhiteSpace(searchdata.email))
                    query = query.Where(x => x.email == searchdata.email);

                if (searchdata.revenue_range != null && searchdata.revenue_range?.Count > 0)
                    query = query.Where(x => searchdata.revenue_range.Contains(x.revenue_range));

                if (searchdata.company_size != null && searchdata.company_size?.Count > 0)
                    query = query.Where(x => searchdata.company_size.Contains(x.company_size));


                if (!string.IsNullOrWhiteSpace(searchdata.company_name))
                    query = query.Where(x => x.company_name.Contains(searchdata.company_name));


                if (!string.IsNullOrWhiteSpace(searchdata.lead_titles))
                    query = query.Where(x => x.lead_titles.Contains(searchdata.lead_titles));


                if (!string.IsNullOrWhiteSpace(searchdata.company_naics_code))
                    query = query.Where(x => x.company_naics_code == searchdata.company_naics_code);

                if (!string.IsNullOrWhiteSpace(searchdata.company_sic_code))
                    query = query.Where(x => x.company_sic_code == searchdata.company_sic_code);

                if (!string.IsNullOrWhiteSpace(searchdata.company_profile_image_url))
                    query = query.Where(x => x.company_profile_image_url == searchdata.company_profile_image_url);

                if (!string.IsNullOrWhiteSpace(searchdata.linkedin_url))
                    query = query.Where(x => x.linkedin_url == searchdata.linkedin_url);

               




            }
            var totalCount = await query.CountAsync();

            return totalCount.ToString();
        }

        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody] Customsearchcontact? searchdata, [FromQuery] int? ispageload = 1)
        {

         
            string email = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email, StringComparison.OrdinalIgnoreCase)).Value;
            var uderdata = await _db.tblUsers.Where(x => x.Email == email).FirstOrDefaultAsync();

            if (uderdata == null)
            {
                return RedirectToAction("Index", "Login");
            }

            int AllSearchLimit2 = 0;
            int searchlimitID = Convert.ToInt32(uderdata.Id);
            int searchlimit = Convert.ToInt32(uderdata.searchlimit);
            int searchlimit2 = Convert.ToInt32(uderdata.searchlimit);
            bool isActive = uderdata.isActive;

            var query = _db.tblContacts.AsQueryable();
            
            List<Contact> result = new List<Contact>();
           


            if (searchdata != null)
            {

                if (searchdata.company_industry != null && searchdata.company_industry?.Count > 0)
                    query = query.Where(x => searchdata.company_industry.Contains(x.company_industry));

                if (searchdata.seniority_level != null && searchdata.seniority_level?.Count > 0)
                    query = query.Where(x => searchdata.seniority_level.Contains(x.seniority_level));

                if (searchdata.lead_division != null && searchdata.lead_division?.Count > 0)
                    query = query.Where(x => searchdata.lead_division.Contains(x.lead_division));

                if (searchdata.email_score != null && searchdata.email_score?.Count > 0)
                    query = query.Where(x => searchdata.email_score.Contains(x.email_score));

                if (!string.IsNullOrWhiteSpace(searchdata.company_name))
                    query = query.Where(x => x.company_name.Contains(searchdata.company_name));

                if (!string.IsNullOrWhiteSpace(searchdata.keyword))
                    query = query.Where(x => x.company_sector.Contains(searchdata.keyword));

                if (searchdata.company_size != null && searchdata.company_size?.Count > 0)
                    query = query.Where(x => searchdata.company_size.Contains(x.company_size));


                if (!string.IsNullOrWhiteSpace(searchdata.lead_titles))
                    query = query.Where(x => x.lead_titles.Contains(searchdata.lead_titles));



                if (!string.IsNullOrWhiteSpace(searchdata.email))
                    query = query.Where(x => x.email.Contains(searchdata.email));

                if (!string.IsNullOrWhiteSpace(searchdata.name))
                    query = query.Where(x => x.name.Contains(searchdata.name));

                if (searchdata.revenue_range != null && searchdata.revenue_range?.Count > 0)
                    query = query.Where(x => searchdata.revenue_range.Contains(x.revenue_range));

                if (!string.IsNullOrWhiteSpace(searchdata.lead_location))
                    query = query.Where(x => x.lead_location == searchdata.lead_location);

                if (!string.IsNullOrWhiteSpace(searchdata.company_naics_code))
                    query = query.Where(x => x.company_naics_code == searchdata.company_naics_code);

                if (!string.IsNullOrWhiteSpace(searchdata.company_sic_code))
                    query = query.Where(x => x.company_sic_code == searchdata.company_sic_code);

                if (!string.IsNullOrWhiteSpace(searchdata.company_profile_image_url))
                    query = query.Where(x => x.company_profile_image_url == searchdata.company_profile_image_url);

                if (!string.IsNullOrWhiteSpace(searchdata.linkedin_url))
                    query = query.Where(x => x.linkedin_url == searchdata.linkedin_url);

        

            }
            try
            {

                AllSearchLimit2 = _db.tblSearchlimit.Where(option => option.SearchBy == uderdata.Id && option.SearchLimitDate.Date == DateTime.Today).Select(option => option.SearchLimitCount).Sum();
            } catch (Exception ex) { }
                if (AllSearchLimit2 <= searchlimit2)
                {


                    //var datacount = await query.CountAsync();
                    //_ = Task.Run(() => getTotalContacswithquery(searchdata));
                    int pasesize = 100;
                    if (ispageload == 0)
                    {
                        pasesize = 1250;
                    }


                    var millionNo = 1000000;
                    var queryData = await query
              .AsNoTracking()
              .OrderBy(x => x.Ids)
              .Take(pasesize)
              .ToListAsync();


                foreach (var item in queryData)
                    {

                    string fullDomain = item.company_website.StartsWith("http") ? item.company_website : $"https://{item.company_website}";
                    string linkedinurl = item.company_website.StartsWith("http") ? item.linkedin_url : $"{item.linkedin_url}";
                    item.Ids = item.Ids;
                    ////item.first_name = $"<h6 style='font-weight:bold;' class=\"mb-3\">{item.first_name} {item.last_name}<h6>" +
                    ////                    $"<br>" +
                    ////                    $"<div class=\"btn-group gap-2\" role=\"group\" aria-label=\"Basic example\">" +
                    ////                    $"<a href=\"{fullDomain}\" target=\"_blank\"><img src=\"/images/web-link.png\" alt=\"domain\" width=\"25px\" height=\"25px\" /></a>" +
                    ////                     $"<a href=\"mailto:{item.work_email}\" target=\"_blank\"><img src=\"/images/email-marketing.png\" alt=\"domain\" width=\"25px\" height=\"25px\" /></a>" +
                    ////                      $"<a href=\"tel:{item.work_mobile}\" target=\"_blank\"><img src=\"/images/phone-call.png\" alt=\"domain\" width=\"25px\" height=\"25px\" /></a>" +
                    ////                      $"<a href=\"{linkedinurl}\" target=\"_blank\"><img src=\"/images/linkedin.png\" alt=\"domain\" width=\"25px\" height=\"25px\" /></a>" +
                    ////                      $"<a href=\"{twiterurl}\" target=\"_blank\"><img src=\"/images/twitter.png\" alt=\"domain\" width=\"25px\" height=\"25px\" /></a>" +
                    ////                      $"<a href=\"mailto:{item.personal_email}\" target=\"_blank\"><img src=\"/images/envelope.png\" alt=\"domain\" width=\"25px\" height=\"25px\" /></a>" +
                    ////                    $"</div>";

                   
                    //  item.name = $"{item.name} <img src=\"/images/verify.png\" alt=\"verify\" width=\"15px\" height=\"15px\" />";
                    item.name = item.name;
                    item.lead_titles = item.lead_titles;
                    item.seniority_level = item.seniority_level;
                    item.lead_division = item.lead_division;
                    item.company_name = item.company_name;
                   // item.company_name = $"<img src=\"https://{item.company_profile_image_url}\" alt=\"verify\" width=\"30px\" height=\"30px\" /> {item.company_name}";
                    item.lead_location = item.lead_location;
                    item.work_phone = item.work_phone;
                    item.company_website = fullDomain;
                    item.linkedin_url = linkedinurl;
                    item.company_phone_numbers = item.company_phone_numbers;
                    item.phone = item.phone;
                    item.email = item.email;
                    item.company_industry = item.company_industry;
                    item.revenue_range = item.revenue_range;
                    item.company_size = item.company_size;
                    item.company_naics_code = item.company_naics_code;
                    item.company_sic_code = item.company_sic_code;
                    item.lead_division = item.lead_division;
                    item.email_score = item.email_score;
                    result.Add(item);

                  


                }

            


            }

                int AllSearchLimit = 0;
                int remval = 0;
                var key2 = email.Replace("@", "_").Replace(".", "_") + "rem";
                var tempserachlimit = await _db.tblSearchlimit.Where(x => x.SearchBy == searchlimitID).FirstOrDefaultAsync();


                if (searchlimit != null && ispageload == 0 && result != null)
                {
                    searchlimit = 1;
                }
                if (tempserachlimit != null)
                {

                    AllSearchLimit = _db.tblSearchlimit.Where(option => option.SearchBy == uderdata.Id && option.SearchLimitDate.Date == DateTime.Today).Select(option => option.SearchLimitCount).Sum();

                }

                if (ispageload == 0 && AllSearchLimit != searchlimit2 + 1)
                {
                    _db.tblSearchlimit.Add(
                      new SearchLimit
                      {
                          Id = 0,
                          SearchLimitCount = searchlimit,
                          SearchLimitDate = DateTime.Now,
                          SearchBy = uderdata.Id,
                          Email = uderdata.Email,
                          password = uderdata.password
                      }
                      );
                    _db.SaveChanges();
                }



                if (searchlimit2 - AllSearchLimit > 0)
                {
                    remval = (searchlimit2 - AllSearchLimit);
                }
                else
                {
                    remval = 0;
                }


                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Delete(key2);
                if (remval == 0 && AllSearchLimit >= searchlimit2 + 1)
                {

                     Response.Headers.Add("remval", remval.ToString());
                     return Json(null);


                }
                Response.Cookies.Append(key2, remval.ToString(), option);

            //if (datacount >= millionNo)
            //{
            //    Response.Headers.Add("tcount", "1M+");
            //}
            //else
            //{
            //    string formattedCount = datacount.ToString("#,0");
            //    Response.Headers.Add("tcount", formattedCount);

            //}


            return Json(new { data = result });
          

        }


        [HttpPost]
        public async Task<IActionResult> Export([FromBody] Customsearchcontact? searchdata)
        {
            string email = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email, StringComparison.OrdinalIgnoreCase)).Value;
            var uderdata = await _db.tblUsers.Where(x => x.Email == email).FirstOrDefaultAsync();
            if (uderdata == null)
            {
                return RedirectToAction("Index", "Login");
            }
    
            var query = _db.tblContacts.AsQueryable();

            if (searchdata != null)
            {
              

                if (searchdata.company_industry != null && searchdata.company_industry?.Count > 0)
                    query = query.Where(x => searchdata.company_industry.Contains(x.company_industry));


                if (searchdata.seniority_level != null && searchdata.seniority_level?.Count > 0)
                    query = query.Where(x => searchdata.seniority_level.Contains(x.seniority_level));

                if (!string.IsNullOrWhiteSpace(searchdata.company_name))
                    query = query.Where(x => x.company_name.Contains(searchdata.company_name));
                if (!string.IsNullOrWhiteSpace(searchdata.keyword))
                    query = query.Where(x => x.company_sector.Contains(searchdata.keyword));

                if (searchdata.company_size != null && searchdata.company_size?.Count > 0)
                    query = query.Where(x => searchdata.company_size.Contains(x.company_size));

              

                if (!string.IsNullOrWhiteSpace(searchdata.lead_titles))
                    query = query.Where(x => x.lead_titles.Contains(searchdata.lead_titles));

                if (searchdata.revenue_range != null && searchdata.revenue_range?.Count > 0)
                    query = query.Where(x => searchdata.revenue_range.Contains(x.revenue_range));

              
                if (!string.IsNullOrWhiteSpace(searchdata.email))
                    query = query.Where(x => x.email.Contains(searchdata.email));

                if (!string.IsNullOrWhiteSpace(searchdata.name))
                    query = query.Where(x => x.name.Contains(searchdata.name));




                if (searchdata.revenue_range != null && searchdata.revenue_range?.Count > 0)
                    query = query.Where(x => searchdata.revenue_range.Contains(x.revenue_range));

            }
            int remval = 0;
            var key2 = email.Replace("@", "_").Replace(".", "_") + "rem";
            int exportlimit = Convert.ToInt32(searchdata.PerExportLimit);
            int todayexportlimit = Convert.ToInt32(uderdata.ExportTodayLimit);


            int AllExports = _db.tblUserExport.Where(option => option.ExportBy == uderdata.Id && option.ExportDate.Date == DateTime.Today).Select(option => option.ExportCount).Sum();

            if (exportlimit > uderdata.PerExportLimit)
            {
                Response.Headers.Add("perlimitavailable", "N");
                Response.Headers.Add("limitavailable", "");


                return Json(null);
            }

            if ((todayexportlimit - AllExports) > 0 && todayexportlimit >= exportlimit)
            {
                remval = (todayexportlimit - AllExports);
            }
            else
            {
                remval = 0;
            }


            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Delete(key2);
            if (remval == 0 || exportlimit > remval)
            {
                Response.Headers.Add("limitavailable", "N");
                Response.Headers.Add("perlimitavailable", "");

                return Json(null);
            }

            List<ContactExportDto> result = null;
            if (remval <= todayexportlimit)
            {
                result = await query.OrderBy(x => x.Ids).Take(exportlimit)
                    .Select(x => new ContactExportDto
                    {

                        id = x.id,
                        company_id = x.company_id,
                        name = x.name,
                        email = x.email,
                        email_score = x.email_score,
                        phone = x.phone,
                        work_phone = x.work_phone,
                        lead_location = x.lead_location,
                        lead_divison = x.lead_division,
                        lead_titles = x.lead_titles,
                        decision_making_power = x.decision_making_power,
                        seniority_level = x.seniority_level,
                        linkedin_url = x.linkedin_url,
                        skills = x.skills,
                        past_companies = x.past_companies,
                        company_name = x.company_name,
                        company_size = x.company_size,
                        company_website = x.company_website,
                        company_phone_numbers = x.company_phone_numbers,
                        company_location_text = x.company_location_text,
                        company_type = x.company_type,
                        company_function = x.company_function,
                        company_sector = x.company_sector,
                        company_industry = x.company_industry,
                        company_founded_at = x.company_founded_at,
                        company_funding_range = x.company_funding_range,
                        revenue_range = x.revenue_range,
                        ebitda_range = x.ebitda_range,
                        company_facebook_page = x.company_facebook_page,
                        company_twitter_page = x.company_twitter_page,
                        company_linkedin_page =x.company_linkedin_page,
                        company_sic_code = x.company_sic_code,
                        company_naics_code = x.company_naics_code,
                        company_description = x.company_description,
                        company_size_key = x.company_size_key,
                        company_profile_image_url = x.company_profile_image_url




                    })
                    .ToListAsync();
                if (remval > 0)
                {
                    remval = remval - exportlimit;
                }
                else
                {
                    remval = todayexportlimit - exportlimit;
                }

                if (remval <= 0)
                {
                    remval = 0;
                }
            }
            else if (remval < exportlimit && remval > 0)
            {
                result = await query.OrderBy(x => x.Ids).Take(remval)
                    .Select(x => new ContactExportDto
                    {
                        id = x.id,
                        company_id = x.company_id,
                        name = x.name,
                        email = x.email,
                        email_score = x.email_score,
                        phone = x.phone,
                        work_phone = x.work_phone,
                        lead_location = x.lead_location,
                        lead_divison = x.lead_division,
                        lead_titles = x.lead_titles,
                        decision_making_power = x.decision_making_power,
                        seniority_level = x.seniority_level,
                        linkedin_url = x.linkedin_url,
                        skills = x.skills,
                        past_companies = x.past_companies,
                        company_name = x.company_name,
                        company_size = x.company_size,
                        company_website = x.company_website,
                        company_phone_numbers = x.company_phone_numbers,
                        company_location_text = x.company_location_text,
                        company_type = x.company_type,
                        company_function = x.company_function,
                        company_sector = x.company_sector,
                        company_industry = x.company_industry,
                        company_founded_at = x.company_founded_at,
                        company_funding_range = x.company_funding_range,
                        revenue_range = x.revenue_range,
                        ebitda_range = x.ebitda_range,
                        company_facebook_page = x.company_facebook_page,
                        company_twitter_page = x.company_twitter_page,
                        company_linkedin_page = x.company_linkedin_page,
                        company_sic_code = x.company_sic_code,
                        company_naics_code = x.company_naics_code,
                        company_description = x.company_description,
                        company_size_key = x.company_size_key,
                        company_profile_image_url = x.company_profile_image_url


                    })
                    .ToListAsync();
                remval = 0;
            }
            Response.Headers.Add("remval", remval.ToString());
            Response.Headers.Add("limitavailable", "Y");
            Response.Headers.Add("perlimitavailable", "Y");

            Response.Cookies.Append(key2, remval.ToString(), option);

            _db.tblUserExport.Add(
                new UserExport
                {
                    Id = 0,
                    ExportCount = exportlimit,
                    ExportDate = DateTime.Now,
                    ExportBy = uderdata.Id
                }
                );
            _db.SaveChanges();
            int AllExports1 = _db.tblUserExport.Where(option => option.ExportBy == uderdata.Id && option.ExportDate.Date == DateTime.Today).Select(option => option.ExportCount).Sum();
            ViewBag.rem = (exportlimit - AllExports1).ToString();
            return Json(result);
           
        }

      



    }
}
