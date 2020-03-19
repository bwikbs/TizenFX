using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Sensor.Tizen.Sensor.EventData
{
    /// <summary>
    /// The BatchData class is used for storing value of particular batch type sensor.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public abstract class BatchData
    {
        /// <summary>
        /// Initializes a new instance of the BatchData class.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <param name="timeStamp">Timestamp of sensor event.</param>
        /// <param name="accuracy">Sensor accuracy of sensor event.</param>
        public BatchData(TimeSpan timeStamp, SensorDataAccuracy accuracy)
        {
            Timestamp = timeStamp;
            Accuracy = accuracy;
        }

        /// <summary>
        /// Gets the value of the HeartRateMonitorBatch Timestamp.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> TimeSpan </value>
        public TimeSpan Timestamp
        {
            get; private set;
        }

        /// <summary>
        /// Gets the accuracy of the HeartRateMonitorBatch data.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> Accuracy </value>
        public SensorDataAccuracy Accuracy { get; private set; } = SensorDataAccuracy.Undefined;
    }
}
