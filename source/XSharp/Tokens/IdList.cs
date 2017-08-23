﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XSharp.Tokens {
  public abstract class IdList : ID {
    protected string[] mList;

    protected IdList(bool aUpper = true) : base(null, aUpper) {
      mList = GetList();
    }

    protected abstract string[] GetList();

    protected override object IsMatch(string aValue) {
      if (mList.Contains(aValue)) {
        return aValue;
      }
      return null;
    }
  }
}