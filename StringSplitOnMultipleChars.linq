<Query Kind="Expression" />

"one;two, three;four,five,,;six".Split(new[] {',', ';'}, StringSplitOptions.RemoveEmptyEntries).Select(p=>p.Trim()).ToList()