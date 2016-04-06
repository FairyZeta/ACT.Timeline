using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Prism.Mvvm;
using Prism.Commands;
using FairyZeta.FF14.ACT;
using FairyZeta.FF14.ACT.Process;
using FairyZeta.FF14.ACT.DataModel;

namespace FairyZeta.FF14.ACT.Timeline.Test.Component
{
    /// <summary> タイマーテストコンポーネント
    /// </summary>
    public class TimerTestComponent : BindableBase
    {
        #region #- [Property] double.Time - ＜時間＞ -----
        /// <summary> 時間 </summary>
        private double _Time;
        /// <summary> 時間 </summary>
        public double Time
        {
            get { return this._Time; }
            set
            {
                if (this._Time == value) return;
                
                this._Time = value;
                base.OnPropertyChanged("Time");
            }
        }
        #endregion

        public TimerSetDataModel TimerDataModel { get; private set; }
        public ActTimerProcess ActTimerProcess { get; private set; }

        public TimerTestComponent()
        {
            this.initComponent();
        }

        /// <summary> コンポーネントの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initComponent()
        {
            this.ActTimerProcess = new ActTimerProcess();
            this.TimerDataModel = new TimerSetDataModel();

            this.TimerDataModel.TimerAutoReset = true;
            this.TimerDataModel.TimerInterval = 100.0;
            this.TimerDataModel.TimerEvent = this.TimerEvent;

            this.ActTimerProcess.TimerSetup(this.TimerDataModel);

            return true;
        }

        public void TimerEvent(object o, ElapsedEventArgs e)
        {
            this.Time += 0.1;
        }


        #region #- [Command] DelegateCommand<TimerOperation>.TimerControlCommand - ＜タイマー操作コマンド＞ -----
        /// <summary> タイマー操作コマンド＜コマンド＞ </summary>
        private DelegateCommand<string> _TimerControlCommand;
        /// <summary> タイマー操作コマンド＜コマンド＞ </summary>
        public DelegateCommand<string> TimerControlCommand
        {
            get { return _TimerControlCommand = _TimerControlCommand ?? new DelegateCommand<string>(this._TimerControlExecute, this._CanTimerControlExecute); }
        }
        #endregion 

        #region #- [Method] CanExecute,Execute @ TimerControlCommand - ＜タイマー操作コマンド＞ -----
        /// <summary> 実行可能確認＜タイマー操作コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanTimerControlExecute(string para)
        {
            return true;
        }

        /// <summary> コマンド実行＜タイマー操作コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _TimerControlExecute(string para)
        {
            switch(para)
            {
                case "Start":
                    this.ActTimerProcess.TimerStart();
                    break;
                case "Stop":
                    this.Time = 0.0;
                    this.ActTimerProcess.TimerStop();
                    break;
                case "Pause":
                    this.ActTimerProcess.TimerStop();
                    break;
                case "ReBoot":
                    this.Time = 0.0;
                    this.ActTimerProcess.TimerReBoot();
                    break;
            }
        }
        #endregion 


    }
}
