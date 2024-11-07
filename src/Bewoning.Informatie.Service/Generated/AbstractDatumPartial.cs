namespace Bewoning.Informatie.Service.Generated;

[Newtonsoft.Json.JsonConverter(typeof(JsonInheritanceConverter), "type")]
[JsonInheritanceAttribute("Datum", typeof(VolledigeDatum))]
[JsonInheritanceAttribute("DatumOnbekend", typeof(DatumOnbekend))]
[JsonInheritanceAttribute("JaarDatum", typeof(JaarDatum))]
[JsonInheritanceAttribute("JaarMaandDatum", typeof(JaarMaandDatum))]
public partial class AbstractDatum
{
    [Newtonsoft.Json.JsonProperty("langFormaat", Required = Newtonsoft.Json.Required.Always)]
    public string LangFormaat { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }

    }

    private static DateTime? ToDateTime(AbstractDatum datum)
    {
        return datum switch
        {
            VolledigeDatum v => v.Datum!.Value.DateTime,
            JaarDatum v => new DateTime(v.Jaar, 1, 1).AddYears(1),
            JaarMaandDatum v => new DateTime(v.Jaar, v.Maand, 1).AddMonths(1),
            _ => null
        };
    }

    public static bool operator <= (AbstractDatum d, DateTime e)
    {
        var peildatum = ToDateTime(d);
        return peildatum != null && peildatum <= e;
    }
    
    public static bool operator >=(AbstractDatum d, DateTime e)
    {
        var peildatum = ToDateTime(d);
        return peildatum != null && peildatum >= e;
    }

    private static (int year, int month, int day) ToYearMonthDay(AbstractDatum datum)
    {
        return datum switch
        {
            VolledigeDatum v => (v.Datum!.Value.Year, v.Datum!.Value.Month, v.Datum!.Value.Day),
            JaarMaandDatum v => (v.Jaar, v.Maand, 0),
            JaarDatum v => (v.Jaar, 0, 0),
            _ => (0, 0, 0),
        };
    }

    public static bool operator <(AbstractDatum left, AbstractDatum right)
    {
        (var leftYear, var leftMonth, var leftDay) = ToYearMonthDay(left);
        (var rightYear, var rightMonth, var rightDay) = ToYearMonthDay(right);

        return leftYear < rightYear ||
            (leftYear == rightYear && leftMonth < rightMonth) ||
            (leftYear == rightYear && leftMonth == rightMonth && leftDay < rightDay);
    }

    public static bool operator >(AbstractDatum left, AbstractDatum right)
    {
        (var leftYear, var leftMonth, var leftDay) = ToYearMonthDay(left);
        (var rightYear, var rightMonth, var rightDay) = ToYearMonthDay(right);

        return leftYear > rightYear ||
            (leftYear == rightYear && leftMonth > rightMonth) ||
            (leftYear == rightYear && leftMonth == rightMonth && leftDay > rightDay);
    }

    /// <summary>
    /// Datum conform iso8601
    /// </summary>
    public partial class VolledigeDatum : AbstractDatum
    {
        [Newtonsoft.Json.JsonProperty("datum", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(DateFormatConverter))]
        public System.DateTimeOffset? Datum { get; set; }

    }

    /// <summary>
    /// representatie voor een volledig onbekend datum
    /// </summary>
    public partial class DatumOnbekend : AbstractDatum
    {
        [Newtonsoft.Json.JsonProperty("onbekend", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? Onbekend { get; set; } = true;

    }

    /// <summary>
    /// representatie voor een datum waarvan maand en dag onbekend zijn
    /// </summary>
    public partial class JaarDatum : AbstractDatum
    {
        [Newtonsoft.Json.JsonProperty("jaar", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Jaar { get; set; }

    }

    /// <summary>
    /// representatie voor een datum waarvan de dag onbekend is
    /// </summary>
    public partial class JaarMaandDatum : AbstractDatum
    {
        [Newtonsoft.Json.JsonProperty("jaar", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Jaar { get; set; }

        [Newtonsoft.Json.JsonProperty("maand", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Maand { get; set; }

    }
}
