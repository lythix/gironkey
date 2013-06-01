namespace Gironkey.Models
{
    public class Rootobject
    {
        public string type { get; set; }
        public Feature[] features { get; set; }
        public Crs crs { get; set; }
        public float[] bbox { get; set; }
    }

    public class Crs
    {
        public string type { get; set; }
        public Properties properties { get; set; }
    }

    public class Properties
    {
        public string code { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public string id { get; set; }
        public Geometry geometry { get; set; }
        public string geometry_name { get; set; }
        public Properties1 properties { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public float[][][][] coordinates { get; set; }
    }

    public class Properties1
    {
        public int ogc_fid { get; set; }
        public int polygon_number { get; set; }
        public int land_id_number { get; set; }
        public int usage_code { get; set; }
        public string view_scale { get; set; }
        public string lot_name { get; set; }
        public string piparcel { get; set; }
        public string pityp { get; set; }
        public object alt_pityp { get; set; }
        public int fol_rec_id { get; set; }
        public int lot_number { get; set; }
        public string lot_type { get; set; }
        public string address_no_type { get; set; }
        public int address_no_from { get; set; }
        public string address_no_from_suffix { get; set; }
        public object address_no_to { get; set; }
        public string rd_name { get; set; }
        public string rd_type { get; set; }
        public string locality { get; set; }
        public string postcode { get; set; }
        public string state { get; set; }
        public float centlat { get; set; }
        public float centlong { get; set; }
        public int zone { get; set; }
        public float legal_area { get; set; }
        public string register { get; set; }
        public string proprietor { get; set; }
        public int dlg_id { get; set; }
        public string dealing_prefix { get; set; }
        public int dealing_number { get; set; }
        public string dealing_suffix { get; set; }
        public int dealing_year { get; set; }
        public int area { get; set; }
        public string dealing_type { get; set; }
        public object region { get; set; }
        public object organisation_code { get; set; }
        public string family_name { get; set; }
        public string given_name { get; set; }
        public string date_execution { get; set; }
        public string sale_date { get; set; }
        public string date_time_legal { get; set; }
        public string date_time_polygon_created { get; set; }
        public string date_time_polygon_modified { get; set; }
        public string date_time_boundary_modified { get; set; }
        public float[] bbox { get; set; }
    }
}