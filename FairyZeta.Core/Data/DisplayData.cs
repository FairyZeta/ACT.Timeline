using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FairyZeta.Core.Data
{
    /// <summary> FZ／ディスプレイデータ
    /// </summary>
    public class DisplayData
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 解像度通称
        /// </summary>
        public string Name { get; set; }

        /// <summary> 縦サイズ
        /// </summary>
        public double Height { get; set; }

        /// <summary> 横サイズ
        /// </summary>
        public double Width { get; set; }

        /// <summary> アスペクト比
        /// </summary>
        public string AspectRatio 
        {
            get { return string.Format("{0}:{1}", this.AspectX, this.AspectY); }
        }

        /// <summary> アスペクト比：縦
        /// </summary>
        public double AspectY { get; set; }

        /// <summary> アスペクト比：横
        /// </summary>
        public double AspectX { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> FZ／ディスプレイデータ／コンストラクタ
        /// </summary>
        /// <param name="pName"> 解像度通称 </param>
        /// <param name="pHeight"> 縦サイズ </param>
        /// <param name="pWidth"> 横サイズ </param>
        /// <param name="pAspectY"> アスペクト比：縦 </param>
        /// <param name="pAspectX"> アスペクト比：横 </param>
        public DisplayData(string pName, double pHeight, double pWidth, double pAspectY, double pAspectX)
            : this()
        {
            this.Name = pName;
            this.Height = pHeight;
            this.Width = pWidth;
            this.AspectY = pAspectY;
            this.AspectX = pAspectX;
        }

        /// <summary> FZ／ディスプレイデータ／コンストラクタ
        /// </summary>
        public DisplayData()
        {
            this.initData();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initData()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
