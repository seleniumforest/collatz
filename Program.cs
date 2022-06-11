using Plotly.NET;

const int start = 10;
const int count = 10;

List<int> getSequence(int num)
{
    var steps = new List<int>() { num };

    while (steps[steps.Count - 1] != 1)
    {
        var lastNumber = steps[steps.Count - 1];
        steps.Add(lastNumber % 2 == 0 ? lastNumber / 2 : lastNumber * 3 + 1);
    }

    return steps;
}

Chart.Combine(
    Enumerable.Range(start, count)
    .ToList()
    .Select(num => {
        var seq = getSequence(num);
        var chart = Chart2D.Chart.Line<int, int, int>(
            x: Enumerable.Range(0, seq.Count), 
            y: seq, 
            ShowLegend: true, 
            Name: $"Number {num}");
        return chart;
    })
)
.WithSize(1300, 700)
.Show();