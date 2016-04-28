using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.ObjectModel
{
    /// <summary> オーバーレイ／プレビューオブジェクトモデル
    /// </summary>
    public class OverlayPreviewObjectModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> プレビュー用タイマーデータ
        /// </summary>
        public TimerData TimerData { get; set; }

        /// <summary> プレビュー用アクティビティコレクション
        /// </summary>
        public ObservableCollection<TimelineActivityData> ActivityCollection { get; set; }
        /// <summary> プレビュー用アクティビティビューソース
        /// </summary>
        public CollectionViewSource ActivityViewSource { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
    
        /// <summary> オーバーレイ／プレビューオブジェクトモデル
        /// </summary>
        public OverlayPreviewObjectModel()
        {
            this.initObjectModel();
            this.CreatePreviewData();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オブジェクトモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initObjectModel()
        {
            this.TimerData = new TimerData();
            this.ActivityCollection = new ObservableCollection<TimelineActivityData>();
            this.ActivityViewSource = new CollectionViewSource() { Source = this.ActivityCollection };
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> プレビュー用データの作成を実行します。
        /// </summary>
        public void CreatePreviewData()
        {
            this.TimerData.CurrentCombatTime = 2.5;


            for (double d = 0; d < 14.0; d += 1.0)
            {
                TimelineActivityData item = new TimelineActivityData();
                item.Index = Convert.ToInt32(d);
                item.TimeFromStart = d;
                item.TimerData = this.TimerData;

                switch (item.Index)
                {
                    case 0:
                        item.Name = "Type:ENEMY";
                        item.TimelineType = TimelineType.ENEMY;
                        item.TimelineAnchorData = new TimelineAnchorData() { Jump = -1 };
                        item.TimelineAlert = new TimelineAlertObjectModel();
                        item.Duration = 3;
                        break;
                    case 1:
                        item.Name = "メガフレア";
                        item.TimelineType = TimelineType.ENEMY;
                        item.Duration = 3;
                        item.TimelineAnchorData = new TimelineAnchorData() { Jump = 1 };
                        item.TimelineAlert = new TimelineAlertObjectModel();
                        break;

                    case 2:
                        item.Name = "[G] Type:GIMMICK";
                        item.TimelineType = TimelineType.GIMMICK;
                        item.Duration = 3;
                        item.TimelineAnchorData = new TimelineAnchorData() { Jump = -1 };
                        item.TimelineAlert = new TimelineAlertObjectModel();
                        break;
                    case 3:
                        item.Name = "[G] 9時方向に増援";
                        item.TimelineType = TimelineType.GIMMICK;
                        item.TimelineAnchorData = new TimelineAnchorData() { Jump = 1 };
                        item.TimelineAlert = new TimelineAlertObjectModel();
                        break;

                    case 4:
                        item.Name = "[T] Type:TANK";
                        item.TimelineType = TimelineType.TANK;
                        item.TimelineAnchorData = new TimelineAnchorData() { Jump = -1 };
                        item.TimelineAlert = new TimelineAlertObjectModel();
                        break;
                    case 5:
                        item.Name = "[T] インビンシブル";
                        item.TimelineType = TimelineType.TANK;
                        item.TimelineAnchorData = new TimelineAnchorData() { Jump = 1 };
                        item.TimelineAlert = new TimelineAlertObjectModel();
                        break;

                    case 6:
                        item.Name = "[D] Type:DPS";
                        item.TimelineType = TimelineType.DPS;
                        item.TimelineAnchorData = new TimelineAnchorData() { Jump = -1 };
                        item.TimelineAlert = new TimelineAlertObjectModel();
                        break;
                    case 7:
                        item.Name = "[D] 捨身";
                        item.TimelineType = TimelineType.DPS;
                        item.TimelineAlert = new TimelineAlertObjectModel();
                        item.TimelineAnchorData = new TimelineAnchorData() { Jump = 1 };
                        break;

                    case 8:
                        item.Name = "[H] Type:HEALER";
                        item.TimelineType = TimelineType.HEALER;
                        item.TimelineAnchorData = new TimelineAnchorData() { Jump = -1 };
                        item.TimelineAlert = new TimelineAlertObjectModel();
                        break;
                    case 9:
                        item.Name = "[H] ストンスキン";
                        item.TimelineType = TimelineType.HEALER;
                        item.TimelineAnchorData = new TimelineAnchorData() { Jump = 1 };
                        item.TimelineAlert = new TimelineAlertObjectModel();
                        break;

                    case 10:
                        item.Name = "[EGI] Type:Pet";
                        item.TimelineType = TimelineType.PET;
                        item.TimelineAnchorData = new TimelineAnchorData() { Jump = -1 };
                        item.TimelineAlert = new TimelineAlertObjectModel();
                        break;
                    case 11:
                        item.Name = "[FAIRY] 光の囁き";
                        item.TimelineType = TimelineType.PET;
                        item.TimelineAnchorData = new TimelineAnchorData() { Jump = 1 };
                        item.TimelineAlert = new TimelineAlertObjectModel();
                        break;

                    case 12:
                        item.Name = "Type:UNKNOWN";
                        item.TimelineType = TimelineType.UNKNOWN;
                        item.TimelineAnchorData = new TimelineAnchorData() { Jump = -1 };
                        item.TimelineAlert = new TimelineAlertObjectModel();
                        break;
                    case 13:
                        item.Name = "不明型タイムライン";
                        item.TimelineType = TimelineType.UNKNOWN;
                        item.TimelineAnchorData = new TimelineAnchorData() { Jump = 1 };
                        item.TimelineAlert = new TimelineAlertObjectModel();
                        break;



                    default:
                        item.Name = "デザイン＠" + item.TimeFromStart.ToString();
                        item.TimelineType = TimelineType.ENEMY;
                        break;

                }


                this.ActivityCollection.Add(item);
            }

        
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
