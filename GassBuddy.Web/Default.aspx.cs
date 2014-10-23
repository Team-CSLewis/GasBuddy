namespace GassBuddy.Web
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Caching;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using GassBuddy.Data;
    using GassBuddy.Models;

    public partial class Default : Page
    {
        private const int CacheTimeMinutes = 20;

        private GassBuddyData data;

        private string SortExpression
        {
            get
            {
                if (String.IsNullOrWhiteSpace((String)ViewState["SortExpression"]))
                {
                    ViewState["SortExpression"] = "PetrolPrice Ascending";
                }

                return (String)ViewState["SortExpression"];
            }
            set
            {
                ViewState["SortExpression"] = value;
            }
        }

        private string CityFilter
        {
            get
            {
                if (String.IsNullOrWhiteSpace((String)ViewState["CityFilter"]))
                {
                    ViewState["CityFilter"] = "";
                }

                return (String)ViewState["CityFilter"];
            }
            set
            {
                ViewState["CityFilter"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            data = new GassBuddyData();
            if (Page.IsPostBack)
            {
                return;
            }

            DropDownListCities.DataSource = data.GasStations.All()
                                                .Select(x => x.City)
                                                .Distinct()
                                                .ToList();
            DropDownListCities.DataBind();

            GridViewStations.DataSource =
                data.GasStations.All().OrderBy(s => s.DieselPrice + 
                                                    s.PetrolPrice +
                                                    s.LpgPrice)
                                                    .ToList();
            GridViewStations.DataBind();

            if (Cache.Get("gasStationsCount") == null)
            {
                var gasStationsCount = Enumerable.Count(data.GasStations.All());

                Cache.Insert("gasStationsCount",
                             gasStationsCount,
                             null,
                             DateTime.Now.AddMinutes(CacheTimeMinutes),
                             Cache.NoSlidingExpiration);
            }
            LiteralStationsCount.Text = Cache.Get("gasStationsCount").ToString();

            if (Cache.Get("avgDieselPrice") == null)
            {
                var avgDieselPrice = data.GasStations.All().Average(s => s.DieselPrice);

                Cache.Insert("avgDieselPrice",
                             avgDieselPrice,
                             null,
                             DateTime.Now.AddMinutes(CacheTimeMinutes),
                             Cache.NoSlidingExpiration);
            }
            AvgDiselPrice.Text = ((decimal)Cache.Get("avgDieselPrice"))
                .ToString("C", CultureInfo.CreateSpecificCulture("Bg-bg"));

            if (Cache.Get("avgLpgPrice") == null)
            {
                var avgLpgPrice = data.GasStations.All().Average(s => s.LpgPrice);

                Cache.Insert(
                             "avgLpgPrice",
                             avgLpgPrice,
                             null,
                             DateTime.Now.AddMinutes(CacheTimeMinutes),
                             Cache.NoSlidingExpiration);
            }
            AvgLPGPrice.Text = ((decimal)Cache.Get("avgLpgPrice"))
                .ToString("C", CultureInfo.CreateSpecificCulture("Bg-bg"));

            if (Cache.Get("avgPetrolPrice") == null)
            {
                var avgPetrolPrice = data.GasStations.All().Average(s => s.PetrolPrice);

                Cache.Insert("avgPetrolPrice",
                             avgPetrolPrice,
                             null,
                             DateTime.Now.AddMinutes(20),
                             Cache.NoSlidingExpiration);
            }
            AvgPetrolPrice.Text = ((decimal)Cache.Get("avgPetrolPrice"))
                .ToString("C", CultureInfo.CreateSpecificCulture("Bg-bg"));
        }

        protected void GridViewStations_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewStations.PageIndex = e.NewPageIndex;

            var result = GasStationsFilterSort();

            GridViewStations.DataSource = result;
            GridViewStations.DataBind();
        }

        protected void GridViewStations_OnSorting(object sender, GridViewSortEventArgs e)
        {
            SortExpression = e.SortExpression + " " + e.SortDirection;

            var result = GasStationsFilterSort();

            GridViewStations.DataSource = result;
            GridViewStations.DataBind();
        }

        protected void DropDownListCities_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CityFilter = DropDownListCities.SelectedValue;

            var result = GasStationsFilterSort();

            GridViewStations.DataSource = result;
            GridViewStations.DataBind();
        }

        private List<GasStation> GasStationsFilterSort()
        {
            var stations = data.GasStations.All();
            if (!string.IsNullOrWhiteSpace(CityFilter))
            {
                stations = stations.Where(s => s.City == CityFilter);
            }

            stations = stations.OrderBy(s => s.DieselPrice + s.PetrolPrice + s.LpgPrice);
            var result = Sort(stations.ToList(), SortExpression);
            return result;
        }

        public static List<T> Sort<T>(IEnumerable<T> source, string sortExpression)
        {
            string[] sortParts = sortExpression.Split(' ');
            var param = Expression.Parameter(typeof(T), string.Empty);
            var sourceList = source as IList<T> ?? source.ToList();
            try
            {
                var property = Expression.Property(param, sortParts[0]);
                var sortLambda = Expression.Lambda<Func<T, object>>(Expression.Convert(property, typeof(object)), param);

                if (sortParts.Length > 1 && sortParts[1].Equals("Ascending", StringComparison.OrdinalIgnoreCase))
                {
                    return sourceList.AsQueryable().OrderBy(sortLambda).ToList();
                }
                return sourceList.AsQueryable().OrderByDescending(sortLambda).ToList();
            }
            catch (ArgumentException)
            {
                return sourceList.ToList();
            }
        }
    }
}