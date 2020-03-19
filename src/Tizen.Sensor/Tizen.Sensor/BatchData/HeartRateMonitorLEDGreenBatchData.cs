using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Sensor.Tizen.Sensor.EventData
{
    /// <summary>
    /// The HeartRateMonitorLEDGreenBatchData class is used for storing value of HeartRateMonitorLEDGreenBatch sensor.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class HeartRateMonitorLEDGreenBatchData : BatchData
    {
        /// <summary>
        /// Initializes a new instance of the HeartRateMonitorLEDGreenBatchData class.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <param name="timeStamp">Timestamp of HeartRateMonitorLEDGreenBatchData sensor event.</param>
        /// <param name="accuracy">Sensor accuracy of HeartRateMonitorLEDGreenBatchData sensor event.</param>
        /// <param name="green">green of the HeartRateMonitorLEDGreenBatchData sensor event.</param>
        /// <param name="accel_x">accel_x of HeartRateMonitorLEDGreenBatchData sensor event.</param>
        /// <param name="accel_y">accel_y of HeartRateMonitorLEDGreenBatchData sensor event.</param>
        /// <param name="accel_z">accel_z of HeartRateMonitorLEDGreenBatchData sensor event.</param>
        /// <param name="index">rri of HeartRateMonitorLEDGreenBatchData sensor event.</param>
        public HeartRateMonitorLEDGreenBatchData(TimeSpan timeStamp, SensorDataAccuracy accuracy, uint green, uint accel_x, uint accel_y, uint accel_z, uint index) : base(timeStamp, accuracy)
        {
            Green = green;
            ACCEL_X = accel_x;
            ACCEL_Y = accel_y;
            ACCEL_Z = accel_z;
            Index = index;
        }

        /// <summary>
        /// Gets the value of the Green.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> The HeartRateMonitorLEDGreenBatch Green Value. </value>
        public uint Green { get; }

        /// <summary>
        /// Gets the value of the ACCEL_X.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> The HeartRateMonitorLEDGreenBatch ACCEL_X Value. </value>
        public uint ACCEL_X { get; }

        /// <summary>
        /// Gets the value of the ACCEL_Y.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> The HeartRateMonitorLEDGreenBatch ACCEL_Y Value. </value>
        public uint ACCEL_Y { get; }


        /// <summary>
        /// Gets the value of the ACCEL_Z.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> The HeartRateMonitorLEDGreenBatch ACCEL_Z Value. </value>
        public uint ACCEL_Z { get; }


        /// <summary>
        /// Gets the value of the Index.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> The HeartRateMonitorLEDGreenBatch Index Value. </value>
        public uint Index { get; }
    }
}
