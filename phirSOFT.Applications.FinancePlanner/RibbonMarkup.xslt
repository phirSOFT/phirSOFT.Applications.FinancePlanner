<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl ns"
    xmlns:ns="http://schemas.microsoft.com/windows/2009/Ribbon"

>
  <xsl:output method="text" indent="no"/>

  <xsl:template match="Application">
    <xsl:text>

using RibbonLib;
using RibbonLib.Controls;

namespace phirSOFT.Applications.FinancePlanner
{
    partial class Form1
    {
    </xsl:text>
    <xsl:apply-templates select="Application.Commands"/>
    <xsl:text>

        private void InitializeRibbon()
        {
    </xsl:text>
    <xsl:apply-templates select ="*" mode ="Initialize"/>
    <xsl:text>
        }
  </xsl:text>
    <xsl:apply-templates select ="*" mode ="Declare"/>
    <xsl:text>
    }
}
  </xsl:text>

  </xsl:template>
  
  <xsl:template match ="Application.Commands">
  
  </xsl:template>

  <xsl:template match="Command">
    <xsl:text>&#xd;&#xa;</xsl:text>
    <xsl:text>        private const uint </xsl:text>
    <xsl:value-of select="@Name"/>
    <xsl:text> = </xsl:text>
    <xsl:value-of select="@Id"/>
    <xsl:text>;</xsl:text>
  </xsl:template>

  <xsl:template match="Application.Views" mode ="Initialize">
    <xsl:apply-templates select="Ribbon" mode="Initialize" />
    <xsl:apply-templates select="ContextPopup" mode="Initialize" />
  </xsl:template>

  <xsl:template match="Application.Views" mode ="Declare">
    <xsl:apply-templates select="Ribbon" mode="Declare" />
    <xsl:apply-templates select="ContextPopup" mode="Initialize" />
  </xsl:template>

  <xsl:template match="Ribbon" mode ="Initialize">
    <xsl:text>
            ribbon = new Ribbon();
    </xsl:text>
    <xsl:apply-templates select="./*" mode="Initialize" />

  </xsl:template>

  <xsl:template match="Ribbon" mode ="Declare">
    <xsl:text>      Ribbon ribbon;&#xd;&#xa;</xsl:text>
    <xsl:apply-templates select="./*" mode="Declare" />
  </xsl:template>

  <xsl:template match="*" mode="Initialize">
    <xsl:call-template name ="control-init"/>
  </xsl:template>

  <xsl:template match="*" mode="Declare">
    <xsl:call-template name ="control-decl"/>
  </xsl:template>

  <xsl:template name ="control-init">
    <xsl:choose>
      <xsl:when test="@CommandName">
        <xsl:text>            </xsl:text>
        <xsl:value-of select="@CommandName"/>
        <xsl:value-of select="name(.)"/>
        <xsl:text> = new Ribbon</xsl:text>
        <xsl:value-of select="name(.)"/>
        <xsl:text>(ribbon, </xsl:text>
        <xsl:value-of select="@CommandName"/>
        <xsl:text>);&#xd;&#xa;</xsl:text>
      </xsl:when>
    </xsl:choose>
    <xsl:apply-templates select="*" mode="Initialize" />
  </xsl:template>

  <xsl:template name ="control-decl">
    <xsl:choose>
      <xsl:when test="@CommandName">
        <xsl:text>        Ribbon</xsl:text>
        <xsl:value-of select="name(.)"/>
        <xsl:text> </xsl:text>
        <xsl:value-of select="@CommandName"/>
        <xsl:value-of select="name(.)"/>
        <xsl:text>;&#xd;&#xa;</xsl:text>
      </xsl:when>
    </xsl:choose>
    <xsl:apply-templates select="./*" mode="Declare" />
  </xsl:template>


</xsl:stylesheet>