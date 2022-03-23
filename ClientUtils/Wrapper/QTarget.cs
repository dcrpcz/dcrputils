using System;
using CitizenFX.Core;

namespace ClientUtils.Wrapper
{
    public struct QTarget
    {
        public QTarget(object[] options, double distance)
        {
            _options = options;
            _distance = distance;
        }

        public QTarget(object option, double distance)
        {
            _options = new[] { option };
            _distance = distance;
        }

        private object[] _options;
        private double _distance;

        public Object ToObject()
        {
            return new
            {
                options = _options,
                distance = _distance
            };
        }
    }

    public struct QTargetOption
    {
        public QTargetOption(string label, Action action)
        {
            _label = label;
            _action = action;
            _canInteract = null;
            _job = null;
            _item = null;
        }

        public QTargetOption(string label, string eventName) : this(label, () => BaseScript.TriggerEvent(eventName)) { }

        public QTargetOption(string label, Action action, Action canInteract, string[] job, string item)
        {
            _label = label;
            _action = action;
            _job = job;
            _item = item;
            _canInteract = canInteract;
        }

        // Parameters
        private readonly string _label;
        private readonly Action _action;

        // Optional Parameters
        private Action _canInteract;
        private string[] _job;
        private string _item;

        public QTargetOption WithCanInteract(Action canInteract)
        {
            this._canInteract = canInteract;
            return this;
        }

        public QTargetOption WithJob(string[] job)
        {
            this._job = job;
            return this;
        }

        public QTargetOption WithJob(string job)
        {
            this._job = new[] { job };
            return this;
        }

        public QTargetOption WithItem(string item)
        {
            this._item = item;
            return this;
        }

        public Object ToObject()
        {
            return new
            {
                label = _label,
                action = _action,
                canInteract = _canInteract,
                job = _job,
                item = _item
            };
        }
    }
}