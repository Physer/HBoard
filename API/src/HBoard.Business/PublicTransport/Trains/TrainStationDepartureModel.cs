namespace HBoard.Business.PublicTransport.Trains
{
    public class TrainStationDepartureModel
    {
        public string Time { get; set; }
        public string DestinationName { get; set; }
        public TrainStationDepartureModeModel Mode {get;set;}
        public string OperatorName { get; set; }
        public string Platform { get; set; }
        public bool PlatformChanged { get; set; }
        public string Remark { get; set; }
        public string RealtimeState { get; set; }
    }
}
