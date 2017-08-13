﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace XSharp.Lines {
  public abstract class Line {
    public string RawText { get; protected set; }

    public Line(string aLine) {
      RawText = aLine;
    }

    // This could be done with an registration scheme and each class searches on its own. 
    // However this would be a fair bit slower and this area is not expected to be expanded much,
    // nor is it intended for external expansion. Thus we have chosen for a bit of simplicity
    // and speed. If it needs expanded, its easily enough accomplished even with this method.
    public static Line New(string aLine) {
      aLine = aLine.Trim();

      Line xResult = null;
      if (aLine.Length == 0) {
        xResult = new Empty(aLine);

      } else if (aLine[0] == '/') {
        if (aLine.Length > 1) {
          char xChar2 = aLine[1];
          aLine = aLine.Substring(2).TrimStart();

          if (xChar2 == '/') {
            xResult = new Comment(aLine);

          } else if (xChar2 == '$') {
            xResult = new Directive(aLine);

          }

        } else {
          xResult = new XSharp(aLine);
        }
      }

      if (xResult == null) {
        throw new Exception("Unable to determine line type.");
      }
      return xResult;
    }
  }
}