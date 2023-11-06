﻿using Reportify.Extensions;

namespace Reportify.Report.Output;

internal class OutputDataConverter : IOutputDataConverter
{
  //TODO unit tests (e.g. for rounding, behaviour when no positions, etc.)
  public OutputData Convert(Report report)
  {
    var dailySummaries = report.DailyReports
      .Where(d => d.Positions.Any())
      .Select(ConvertToDayGroup)
      .OrderBy(d => d.Date);

    return new OutputData(dailySummaries);
  }

  private static DailySummary ConvertToDayGroup(DailyReport dailyReport)
  {
    var positionGroups = ConvertToPositionGroup(dailyReport.Positions)
      .OrderByDescending(p => p.Duration)
      .ToList();

    return new DailySummary(
      dailyReport.Date,
      positionGroups.Sum(p => p.RoundedDurationInHours),
      positionGroups.Sum(p => p.Duration),
      positionGroups);
  }

  private static IEnumerable<PositionSummary> ConvertToPositionGroup(IEnumerable<Position> positions)
  {
    return positions
      .GroupBy(p => p.ErpPositionId)
      .Select(
        group => new PositionSummary(
          group.Key,
          group.Sum(p => p.Duration),
          group.Sum(p => p.Duration).RoundToQuarterHours(),
          group.Select(p => new Activity(p.Name, p.Duration)).OrderByDescending(a => a.Duration)));
  }
}