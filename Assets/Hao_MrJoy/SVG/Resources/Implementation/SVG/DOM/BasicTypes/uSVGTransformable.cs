public class uSVGTransformable {
  private uSVGTransformList m_inheritTransformList;
  private uSVGTransformList m_currentTransformList;
  private uSVGTransformList m_summaryTransformList;
  /**********************************************************************************/
  public uSVGTransformList inheritTransformList {
    get { return m_inheritTransformList; }
    set {
      int c = 0;
      if(m_inheritTransformList != null) c += m_inheritTransformList.Count;
      if(m_currentTransformList != null) c += m_currentTransformList.Count;
      m_inheritTransformList = value;
      m_summaryTransformList = new uSVGTransformList(c);
      if(m_inheritTransformList != null)
        m_summaryTransformList.AppendItems(m_inheritTransformList);
      if(m_currentTransformList != null)
        m_summaryTransformList.AppendItems(m_currentTransformList);
    }
  }
  public uSVGTransformList currentTransformList {
    get { return m_currentTransformList; }
    set { 
      m_currentTransformList = value;
      int c = 0;
      if(m_inheritTransformList != null) c += m_inheritTransformList.Count;
      if(m_currentTransformList != null) c += m_currentTransformList.Count;
      m_summaryTransformList = new uSVGTransformList(c);
      if(m_inheritTransformList != null)
        m_summaryTransformList.AppendItems(m_inheritTransformList);
      if(m_currentTransformList != null)
        m_summaryTransformList.AppendItems(m_currentTransformList);
    }
  }
  public uSVGTransformList summaryTransformList {
    get { return m_summaryTransformList; }
  }
  public float transformAngle {
    get {
      float m_angle = 0.0f;
      for(int i = 0; i < m_summaryTransformList.Count; i++ ) {
        uSVGTransform m_temp = m_summaryTransformList[i];
        if(m_temp.type == uSVGTransformType.SVG_TRANSFORM_ROTATE) 
          m_angle += m_temp.angle;
      }
      return m_angle;
    }
  }
  public uSVGMatrix transformMatrix {
    get { return summaryTransformList.Consolidate().matrix; }
  }
  /*********************************************************************************************/
  public uSVGTransformable(uSVGTransformList transformList) {
    inheritTransformList = transformList;
  }
}
