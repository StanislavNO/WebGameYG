﻿using System.Collections.Generic;

namespace Assets.Source.Code_base
{
    public class PauseHandler
    {
        private readonly List<IPause> _handlers;

        public PauseHandler()
        {
            _handlers = new();
        }

        public void Add(IPause handler)
        {
            if (_handlers.Contains(handler))
                return;

            _handlers.Add(handler);
        }

        public void Remove(IPause handler)
        {
            if (_handlers.Contains(handler))
                _handlers.Remove(handler);
        }

        public void SetPause(bool isPaused)
        {
            foreach (IPause handler in _handlers)
                handler.SetPause(isPaused);
        }
    }
}
