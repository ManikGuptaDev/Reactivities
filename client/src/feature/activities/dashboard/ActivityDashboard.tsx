import { Grid } from "@mui/material";
import ActivityList from "./ActivityList";
import Activityfilters from "./ActivityFilters";

export default function ActivityDashboard() {


  return (
    <Grid container spacing={2}>
        <Grid size={8}>
<ActivityList 
/>
        </Grid>
        <Grid size={4}>
          <Activityfilters/>
        </Grid>
    </Grid>
  )
}
