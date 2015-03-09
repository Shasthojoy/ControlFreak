namespace ControlFreak.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Livet;

    public class HandleObject : IEnumerable<HandleObject>
    {
        public HandleObject()
            : this(IntPtr.Zero)
        {
        }

        public HandleObject(IntPtr handle)
        {
            this.Handle = handle;
            this.ClassName = string.Empty;
            this.WindowCaption = string.Empty;
            this.Children = new ObservableCollection<HandleObject>();
        }

        public IntPtr Handle { set; get; }
        public HandleObject Parent { set; get; }
        public string ClassName { set; get; }
        public string WindowCaption { set; get; }
        public IList<HandleObject> Children { private set; get; }

        private static HandleObject FindChild(HandleObject parent, IntPtr child)
        {
            foreach (var item in parent.Children)
            {
                if (item.Handle == child)
                    return item;
            }

            return null;
        }

        private static HandleObject FindDescendant(HandleObject parent, IntPtr descendant)
        {
            foreach (var item in parent.Children)
            {
                if (item.Handle == descendant)
                    return item;

                var v = FindDescendant(item, descendant);
                if (v != null)
                    return v;
            }

            return null;
        }

        public HandleObject GetChild(IntPtr child)
        {
            return FindChild(this, child);
        }

        public HandleObject GetDescendant(IntPtr descendant)
        {
            return FindDescendant(this, descendant);
        }

        public override string ToString()
        {
            var parent = IntPtr.Zero;

            if (this.Parent != null)
                parent = this.Parent.Handle;

            if (IntPtr.Size == 8)
                return string.Format("{{ Handle=0x{0:X16}, Parent=0x{1:X16}, ClassName={2}, WindowCaption={3}, ChildrenCount={4} }}", this.Handle.ToInt64(), parent.ToInt64(), this.ClassName, this.WindowCaption, this.Children.Count);
            else
                return string.Format("{{ Handle=0x{0:X8}, Parent=0x{1:X8}, ClassName={2}, WindowCaption={3}, ChildrenCount={4} }}", this.Handle.ToInt32(), parent.ToInt32(), this.ClassName, this.WindowCaption, this.Children.Count);
        }

        public IEnumerator<HandleObject> GetEnumerator()
        {
            foreach (var item in this.Children)
                yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
