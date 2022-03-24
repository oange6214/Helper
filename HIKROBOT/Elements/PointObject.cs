using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HIKROBOT.Elements
{
    public class PointObject : INotifyPropertyChanged, IObject
    {
        public PointObject()
        {
        }

        #region Public Properties

        private double _x;
        /// <summary>
        /// X 軸極座標
        /// </summary>
        public double X
        {
            get { return _x; }
            set { _x = value; RaisePropertyChanged(); }
        }

        private double _y;
        /// <summary>
        /// Y 軸極座標
        /// </summary>
        public double Y
        {
            get { return _y; }
            set { _y = value; RaisePropertyChanged(); }
        }

        private double _width;
        /// <summary>
        /// 機器人寬度
        /// </summary>
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        private double _height;
        /// <summary>
        /// 機器人高度
        /// </summary>
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private string _sourceImage;
        /// <summary>
        /// 來源圖片
        /// </summary>
        public string SourceImage
        {
            get { return _sourceImage; }
            set
            {
                _sourceImage = value;
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
