namespace CourseWorkSample
{
    internal class FormClosingEventArgs
    {
        public object CloseReason { get; internal set; }
        public bool Cancel { get; internal set; }
    }
}