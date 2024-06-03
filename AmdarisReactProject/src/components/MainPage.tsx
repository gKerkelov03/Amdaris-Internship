import {
    Card,
    Container,
    Divider,
    Grid,
    CardContent as MuiCardContent,
    Typography
} from '@mui/material';
import { styled } from '@mui/material/styles';

// Styled components
const Root = styled(Container)(({ theme }) => ({
    marginTop: theme.spacing(4)
}));

const CardWrapper = styled(Card)(({ theme }) => ({
    display: 'flex',
    marginBottom: theme.spacing(2)
}));

const CardContent = styled(MuiCardContent)(() => ({
    flex: '1 0 auto'
}));

const DividerStyled = styled(Divider)(() => ({
    margin: '20px 0'
}));

const salon = {
    name: 'Salon Name',
    specialties: ['Haircut', 'Hair Coloring', 'Manicure', 'Pedicure'],
    description:
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed faucibus justo eu fermentum varius.',
    location: '123 Salon Street, City, Country',
    workers: [
        { name: 'John Doe', role: 'Hair Stylist' },
        { name: 'Jane Doe', role: 'Manicurist' },
        { name: 'Alice Smith', role: 'Hair Stylist' }
    ]
};

const SalonDetailsPage = () => {
    return (
        <Root>
            <Typography variant="h4" gutterBottom>
                {salon.name}
            </Typography>
            <Typography variant="body1" gutterBottom>
                {salon.description}
            </Typography>
            <Typography variant="subtitle1" gutterBottom>
                <strong>Specialties:</strong> {salon.specialties.join(', ')}
            </Typography>
            <Typography variant="subtitle1" gutterBottom>
                <strong>Location:</strong> {salon.location}
            </Typography>

            <DividerStyled />

            <Typography variant="h5" gutterBottom>
                Workers
            </Typography>
            <Grid container spacing={2}>
                {salon.workers.map((worker, index) => (
                    <Grid item xs={12} sm={6} md={4} key={index}>
                        <CardWrapper>
                            <CardContent>
                                <Typography variant="h6">
                                    {worker.name}
                                </Typography>
                                <Typography
                                    variant="subtitle2"
                                    color="textSecondary"
                                >
                                    {worker.role}
                                </Typography>
                            </CardContent>
                        </CardWrapper>
                    </Grid>
                ))}
            </Grid>

            <DividerStyled />
        </Root>
    );
};

export default SalonDetailsPage;
