/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Tizen.Sensor
{
    /// <summary>
    /// The AutoRotationSensor class is used for registering callbacks for the auto rotation sensor and getting the auto rotation data.
    /// </summary>
    public sealed class AutoRotationSensor : Sensor
    {
        private static string AutoRotationKey = "http://tizen.org/feature/sensor.auto_rotation";

        private event EventHandler<SensorAccuracyChangedEventArgs> _accuracyChanged;

        /// <summary>
        /// Gets the value of the rotation state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The rotation state. </value>
        public AutoRotationState Rotaion { get; private set; } = AutoRotationState.Unknown;


        /// <summary>
        /// Gets the accuracy of the auto rotation data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> Accuracy </value>
        public SensorDataAccuracy Accuracy { get; private set; } = SensorDataAccuracy.Undefined;

        /// <summary>
        /// Returns true or false based on whether the auto rotation sensor is supported by the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value><c>true</c> if supported; otherwise <c>false</c>.</value>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the AutoRotationSensor is supported");
                return CheckIfSupported(SensorType.AutoRotation, AutoRotationKey);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.AutoRotationSensor"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/sensor.auto_rotation</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular auto rotation sensor in case of multiple sensors.
        /// </param>
        public AutoRotationSensor(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating AutoRotationSensor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.AutoRotation;
        }

        /// <summary>
        /// An event handler for storing the callback functions for the event corresponding to the change in the auto rotation sensor data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>

        public event EventHandler<AutoRotationSensorDataUpdatedEventArgs> DataUpdated;

        /// <summary>
        /// An event handler for accuracy changed events.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<SensorAccuracyChangedEventArgs> AccuracyChanged
        {
            add
            {
                if (_accuracyChanged == null)
                {
                    AccuracyListenStart();
                }
                _accuracyChanged += value;
            }
            remove
            {
                _accuracyChanged -= value;
                if (_accuracyChanged == null)
                {
                    AccuracyListenStop();
                }
            }
        }

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.AutoRotation, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for auto rotation");
                count = 0;
            }
            else
                Interop.Libc.Free(list);
            return count;
        }

        private static Interop.SensorListener.SensorEventCallback _callback;

        internal override void EventListenStart()
        {
            _callback = (IntPtr sensorHandle, IntPtr eventPtr, IntPtr data) => {
                Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(eventPtr);

                TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
                Rotaion = (AutoRotationState)sensorData.values[0];
                Accuracy = sensorData.accuracy;

                DataUpdated?.Invoke(this, new AutoRotationSensorDataUpdatedEventArgs(sensorData.values, sensorData.accuracy));
            };

            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for auto rotation sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for auto rotation");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for auto rotation sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for auto rotation");
            }
        }

        private static Interop.SensorListener.SensorAccuracyCallback _accuracyCallback;

        private void AccuracyListenStart()
        {
            _accuracyCallback = (IntPtr sensorHandle, UInt64 timestamp, SensorDataAccuracy accuracy, IntPtr data) => {
                TimeSpan = new TimeSpan((Int64)timestamp);
                Accuracy = accuracy;
                _accuracyChanged?.Invoke(this, new SensorAccuracyChangedEventArgs(new TimeSpan((Int64)timestamp), accuracy));
            };

            int error = Interop.SensorListener.SetAccuracyCallback(ListenerHandle, _accuracyCallback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting accuracy event callback for auto rotation sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set accuracy event callback for auto rotation");
            }
        }

        private void AccuracyListenStop()
        {
            int error = Interop.SensorListener.UnsetAccuracyCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting accuracy event callback for auto rotation sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset accuracy event callback for auto rotation");
            }
        }
    }
}
