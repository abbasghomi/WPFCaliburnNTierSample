namespace WPFCaliburnNTierSample.DomainLayer.Common.Models
{
    /// <summary>
    /// Error model to report fluentvalidation resulto to presentation layer without adding dependency to Fluentvalidation in presentation layer
    /// </summary>
    public class ErrorModel
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}