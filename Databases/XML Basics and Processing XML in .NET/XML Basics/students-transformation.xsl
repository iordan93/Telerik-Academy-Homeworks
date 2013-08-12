<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h1>Students</h1>
        <xsl:for-each select="/students/student">
          <ul>
            <li>
              Name:
              <xsl:value-of select="name"/>
            </li>
            <li>
              Sex:
              <xsl:value-of select="sex"/>
            </li>
            <li>
              Birth date:
              <xsl:value-of select="birth-date"/>
            </li>
            <li>
              Phone:
              <xsl:value-of select="phone"/>
            </li>
            <li>
              Email:
              <xsl:value-of select="email"/>
            </li>
            <li>
              Course:
              <xsl:value-of select="course"/>
            </li>
            <li>
              Speciality:
              <xsl:value-of select="speciality"/>
            </li>
            <li>
              Faculty number:
              <xsl:value-of select="faculty-number"/>
            </li>
            <li>
              Enrollment date:
              <xsl:value-of select="enrollment-date"/>
            </li>
            <li>
              Entrance exam result:
              <xsl:value-of select="entrance-exam-result"/>
            </li>
            <xsl:for-each select="exams/exam">
              <li>
                Exam:
                <ul>
                  <li>
                    Name:
                    <xsl:value-of select="exam-name"/>
                  </li>
                  <li>
                    Tutor:
                    <xsl:for-each select="tutor">
                      <ul>
                        <li>
                          Name:
                          <xsl:value-of select="name"/>
                        </li>
                        <li>
                          Endorsements:
                          <xsl:for-each select="endorsements/endorsement">
                            <ul>
                              <li>
                                <xsl:value-of select="."/>
                              </li>
                            </ul>
                          </xsl:for-each>
                        </li>
                      </ul>
                    </xsl:for-each>
                  </li>
                  <li>
                    Score:
                    <xsl:value-of select="score"/>
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
