﻿using System;
using System.Collections.Generic;

namespace ManiaRTRender.Core
{
    public enum Judgement
    {
        Max = 0,
        J300 = 1,
        J200 = 2,
        J100 = 3,
        J50 = 4,
        Miss = 5
    }

    public class BaseNote : IComparable<BaseNote>
    {
        public long TimeStamp = 0;
        public int Column = 0;
        public long Duration = 0;
        public long EndTime => TimeStamp + Duration;

        public int CompareTo(BaseNote other)
        {
            return TimeStamp.CompareTo(other.TimeStamp);
        }

        public void Scale(double rate)
        {
            Duration = (long)(Duration / rate);
            TimeStamp = (long)(TimeStamp / rate);
        }
        
    }

    public class Note : BaseNote
    {
        public Judgement Judgement = Judgement.Miss;
    }

    public class Action : BaseNote
    {
        public Judgement JudgementStart = Judgement.Miss;
        public Judgement JudgementEnd = Judgement.Miss;
        public Note Target;
        public bool IsHolding = false;
    }

    public class ManiaBeatmap
    {
        public int Key = -1;
        public bool IsMania = false;
        public double[] JudgementWindow;
        public IList<Note> Notes;
    }
}
