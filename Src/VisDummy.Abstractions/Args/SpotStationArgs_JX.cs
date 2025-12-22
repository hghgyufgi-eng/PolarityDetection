namespace VisDummy.Abstractions.Args
{
    public class SpotStationArgs_JX
    {
        /// <summary>
        /// 相机号
        /// </summary>
        public ushort CameraNo { get; set; }

        public string ToMsg()
        {
            return $"CameraNo:{CameraNo}";
        }
    }
}
