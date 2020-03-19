using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Sensor.Tizen.Sensor.EventData
{
    /// <summary>
    /// The HeartRateMonitorBatchData class is used for storing value of HeartRateMonitorBatch sensor.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class HeartRateMonitorBatchData : BatchData
    {
        /// <summary>
        /// Initializes a new instance of the HeartRateMonitorBatchData class.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <param name="timeStamp">Timestamp of HeartRateMonitorBatch sensor event.</param>
        /// <param name="accuracy">Sensor accuracy of HeartRateMonitorBatch sensor event.</param>
        /// <param name="state">Value indicating the status of the HeartRateMonitorBatch sensor.</param>
        /// <param name="heartRate">heartRate of HeartRateMonitorBatch sensor event.</param>
        /// <param name="rri">rri of HeartRateMonitorBatch sensor event.</param>
        public HeartRateMonitorBatchData(TimeSpan timeStamp, SensorDataAccuracy accuracy, HeartRateMonitorBatchState state, int heartRate, int rri) : base(timeStamp, accuracy)
        {
            State = state;
            HeartRate = heartRate;
            Rri = rri;
        }

        /// <summary>
        /// Gets the value of the HeartRateMonitorBatch state.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> The HeartRateMonitorBatch state. </value>
        public HeartRateMonitorBatchState State { get; }

        /// <summary>
        /// Gets the value of the HeartRate.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> The HeartRateMonitorBatch HeartRate Value. </value>
        public int HeartRate { get; }

        /// <summary>
        /// Gets the value of the rri.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> The HeartRateMonitorBatch rri Value. </value>
        public int Rri { get; }

    }
}
