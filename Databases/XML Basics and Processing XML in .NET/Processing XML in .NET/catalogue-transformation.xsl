<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h1>Catalogue</h1>
        <xsl:for-each select="/catalogue/album">
          <ul>
            <li>
              Name:
              <xsl:value-of select="name"/>
            </li>
            <li>
              Artist:
              <xsl:value-of select="artist"/>
            </li>
            <li>
              Year:
              <xsl:value-of select="year"/>
            </li>
            <li>
              Producer:
              <xsl:value-of select="producer"/>
            </li>
            <li>
              Price:
              <xsl:value-of select="price"/>
            </li>
            <xsl:for-each select="songs/song">
              <li>
                Song:
                <ul>
                  <li>
                    Title:
                    <xsl:value-of select="title"/>
                  </li>
                  <li>
                    Duration:
                    <xsl:value-of select="duration"/>
                  </li>
                </ul>
              </li>
            </xsl:for-each>
          </ul>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
