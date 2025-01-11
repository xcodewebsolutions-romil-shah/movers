using System.Text.Json.Serialization;

namespace MoverAndStore.WebApp.Models
{
    public class CardData
    {
        [JsonPropertyName("basic_information")]
        public BasicInformation Basic_Information { get; set; }

        [JsonPropertyName("additional_info")]
        public AdditionalInfo Additional_Info { get; set; }

        [JsonPropertyName("moving_date")]
        public MovingDate Moving_Date { get; set; }

        [JsonPropertyName("stockage")]
        public Stockage stockage { get; set; }

        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }

        [JsonPropertyName("notes")]

        public Notes Notes { get; set; }
    }

    public class BasicInformation
    {
        public string id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }
        //public string Address_Group { get; set; }

        [JsonPropertyName("lead")]
        public Lead Lead { get; set; }

        [JsonPropertyName("addresses_group")]
        public AddressGroup AddressGroup { get; set; }
    }
    public class AdditionalInfo
    {
        [JsonPropertyName("extra_info_lift")]

        public string Extra_Info_Lift { get; set; }

        [JsonPropertyName("lift_bool")]
        public bool Lift_bool { get; set; }

        [JsonPropertyName("lift_location_enum")]
        public string Lift_Location_Enum { get; set; }

        [JsonPropertyName("lift_type_enum")]
        public string Lift_Type_Enum { get; set; }

        [JsonPropertyName("voertuig_enum")]
        public string Voertuig_Enum { get; set; }

        [JsonPropertyName("Hour_start_update")]       
        public DateTime Hour_start_update { get; set; }

        [JsonPropertyName("Hour_Stop_Update")]
	    public DateTime Hour_stop_update { get; set; }

        [JsonPropertyName("voertuig_type_enum")]
        public string Voertuig_Type_Enum { get; set; }

        [JsonPropertyName("number_of_movers")]
        public int Number_Of_Movers { get; set; }

        [JsonPropertyName("number_of_movers_update")]
        public int Number_Of_Movers_Update { get; set; }

        [JsonPropertyName("dismantling_bool")]
        public bool Dismantling_Bool { get; set; }

        [JsonPropertyName("dismantling_bool_update")]
        public bool Dismantling_Bool_Update { get; set; }

        [JsonPropertyName("time_estimate")]
        public string Time_Estimate { get; set; }

        [JsonPropertyName("time_estimate_update")]
        public int Time_Estimate_Update { get; set; }

        [JsonPropertyName("items_to_dismantle")]
        public string Items_To_Dismantle { get; set; }

        [JsonPropertyName("items_to_dismantle_update")]
        public string Items_To_Dismantle_Update { get; set; }

        [JsonPropertyName("additional_general_info")]
        public string Additional_General_Info { get; set; }

        [JsonPropertyName("additional_general_info_update")]
        public string Additional_General_Info_update { get; set; }
    }

    public class MovingDate
    {
        public DateTime? moving_from_date { get; set; }

        public DateTime? moving_to_date { get; set; }

        public DateTime? client_arrival_time_update { get; set; }
    }

    public class Stockage
    {
        [JsonPropertyName("date_in")]
        public DateTime? Date_In { get; set; }

        [JsonPropertyName("date_in_update")]
        public string Date_In_Update { get; set; }

        [JsonPropertyName("date_out")]
        public DateTime? Date_Out { get; set; }

        [JsonPropertyName("date_out_update")]
        public string Date_Out_Update { get; set; }

        [JsonPropertyName("cubic_meters")]
        public int  Cubic_Meters { get; set; }

        [JsonPropertyName("cubic_meters_update")]
        public int Cubic_Meters_Update { get; set; }

        [JsonPropertyName("storage")]
        public string Storage { get; set; }

        [JsonPropertyName("storage_update")]
        public string Storage_Update { get; set; }

        [JsonPropertyName("zone")]
        public string Zone { get; set; }

        [JsonPropertyName("zone_update")]
        public string Zone_Update { get; set; }

        [JsonPropertyName("exact_location")]
        public string Exact_Location { get; set; }

        [JsonPropertyName("exact_location_update")]
        public string Exact_Location_Update { get; set; }

        [JsonPropertyName("options_enum")]
        public string Options_Enum { get; set; }

        [JsonPropertyName("insured_value")]
        public string Insured_Value { get; set; }

        [JsonPropertyName("contract")]
        public bool Contract { get; set; }
    }

    public class Lead
    {
        [JsonPropertyName("contact_person")]
        public string Contact_Person { get; set; }

        [JsonPropertyName("customer")]
        public string Customer { get; set; }

        [JsonPropertyName("contact_person_telephone")]
        public string Contact_Person_Telephone { get; set; }

    }

    public class AddressGroup
    {
        [JsonPropertyName("address_a")]
        public string address_a { get; set; }

        [JsonPropertyName("pv_1_bool")]
        public bool pv_1_bool { get; set; }

        [JsonPropertyName("address_b")]
        public string address_b { get; set; }

        [JsonPropertyName("pv_2_bool")]
        public bool pv_2_bool { get; set; }

        [JsonPropertyName("address_c")]
        public string address_c { get; set; }

        [JsonPropertyName("pv_3_bool")]
        public bool pv_3_bool { get; set; }

        [JsonPropertyName("pv_extra_info")]
        public string pv_extra_info { get; set; }

        [JsonPropertyName("pv_requested_enum")]
        public string pv_requested_enum { get; set; }

        [JsonPropertyName("extra_info_contact")]
        public ExtraInfoContact extra_info_contact { get; set; }


    }

    public class ExtraInfoContact
    {
        [JsonPropertyName("general_extra_info")]
        public string general_extra_info { get; set; }
    }

    public class Product
    {
        [JsonPropertyName("id")]

        public string id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("quantity")]
        public int quantity { get; set; }

        [JsonPropertyName("quantity_update")]
        public int quantity_update { get; set; }

    }

    public class Notes
    {
        [JsonPropertyName("foreman_notes")]
        public string foreman_notes { get; set; }
    }
}
